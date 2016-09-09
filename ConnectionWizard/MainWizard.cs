using System;
using System.Windows.Forms;
using System.Collections.Generic;
using AeroWizard;

using ConnectionWizard.Methods;
using ConnectionWizard.Model;

namespace ConnectionWizard
{
    public partial class MainWizard : Form
    {
        //int page_index = 0;
        const string FlowPanelName = "FlowPanel";
        public MainWizard()
        {            
            InitializeComponent();
        }

        private void MainWizard_Load(object sender, EventArgs e)
        {            
            DBMethods db = new DBMethods();
            Wizard_Init( db.GetFormsById(271) );                  
        }

        private void wizardControl_SelectedPageChanged(object sender, EventArgs e)
        {
            
        }

        void wizardPage_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            // If the user hasn't provided a sufficiently long zip code, don't allow the commit
            DBMethods db = new DBMethods();
            int forms_visit_id = 0;

            #region Save_results
            Forms forms = db.GetFormsById(271);
            forms_visit_id = db.SetFormVisit(forms.Id_Form);

            FlowLayoutPanel flpanel = (FlowLayoutPanel)e.Page.Controls[FlowPanelName];
            RadioButton rb = new RadioButton();
            foreach (Control cntrl in flpanel.Controls)
            {
                rb = (RadioButton)cntrl;

                if (rb.Checked == true)
                {                     
                    db.SetFormAnsAbo(new Form_Ans_Abo() { Id_Query = ((Form_Ans)rb.Tag).Id_Query, Id_Ans = ((Form_Ans)rb.Tag).Id_Ans, Id_Visit = forms_visit_id });
                    break;
                }
            }
            #endregion

            #region GetNext
            Form_Query form_query = db.GetNextQuery(forms_visit_id, ((Form_Ans)rb.Tag).Id_Query);
            if (form_query.Num_Query != 0)
            {                
                e.Page.NextPage = wizardControl.Pages.Find(delegate (WizardPage pg) { return ((Form_Query)pg.Tag).Id_Query == form_query.Id_Query; });
            }
            else
            {
                e.Page.NextPage = wizardControl.Pages[wizardControl.Pages.Count - 1];
            }
            #endregion
        }

        // Find page by tag value.
        //WizardPageCollection result = WizardPageCollection.Find(
        //delegate (WizardPage page)
        //{
        //    return ((Form_Query)page.Tag).Id_Query == IDtoFind;
        //}
        //);

        private void wizardPage_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {

        }

        void Wizard_Init(Forms form)
        {
            DBMethods db = new DBMethods();
            List<Form_Query> query_list = db.GetQueryTable();

            wizardControl.Pages.Capacity = query_list.Count;
            wizardControl.Text = form.Name;

            #region Find first question
            foreach (Form_Query query in query_list)
            {
                if (form.Id_Query_First == query.Id_Query)
                {
                    List<Form_Ans> form_answer_list = db.GetQueryAnswer(form.Id_Query_First);
                    WizardPage page = FillPage(query);
                    wizardControl.Pages.Add(page);
                    query_list.Remove(query);
                    break;
                }
            }
            #endregion

            foreach (Form_Query query in query_list)
            {
                WizardPage page = FillPage(query);
                wizardControl.Pages.Add(page);
            }

            #region Finish page
            WizardPage finish_page = new WizardPage();
            finish_page.IsFinishPage = true;
            finish_page.Text = "Конец";
            wizardControl.Pages.Add(finish_page);
            #endregion

            wizardControl.RestartPages();
        }

        FlowLayoutPanel AddAnswerToPanel(int queryid)
        {
            DBMethods db = new DBMethods();
            List<Form_Ans> form_answer_list = db.GetQueryAnswer(queryid);
            FlowLayoutPanel flpanel = new FlowLayoutPanel();

            foreach (Form_Ans form_answer in form_answer_list)
            {
                #region Panel                
                flpanel.FlowDirection = FlowDirection.TopDown;
                flpanel.AutoSize = true;
                flpanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                flpanel.WrapContents = true;
                flpanel.Dock = DockStyle.Fill;
                flpanel.Name = FlowPanelName;
                #endregion

                RadioButton box = new RadioButton();
                box.Text = form_answer.Answer;
                box.AutoSize = true;
                box.Dock = System.Windows.Forms.DockStyle.Fill;
                box.Tag = form_answer;
                flpanel.Controls.Add(box);
            }

            return flpanel;
        }

        WizardPage FillPage(Form_Query query)
        {
            WizardPage page = new WizardPage();

            page.Tag = query;
            page.Text = query.Query;
            page.Commit += wizardPage_Commit;
            page.Controls.Add(AddAnswerToPanel(query.Id_Query));

            return page;
        }
    }
}

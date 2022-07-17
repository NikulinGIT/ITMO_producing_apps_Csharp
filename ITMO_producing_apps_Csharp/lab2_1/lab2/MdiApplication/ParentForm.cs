namespace MdiApplication
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
           
                spData.Text = Convert.ToString(System.DateTime.Today.ToLongDateString());
            

        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WindowCascadeMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
            spWin.Text = "Windows is cascade";
            


        }

        private void WindowsTileMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
         
            spWin.Text = "Windows is horizontal";
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm newChild = new ChildForm();
            newChild.MdiParent = this;
            newChild.Show();
            newChild.Text = newChild.Text + " " + ++openDocuments;

        }

        private void ParentForm_Load(object sender, EventArgs e)
        {

        }

        private void ParentForm_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {


        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag.ToString())
            {
                case "NewDoc":
                    ChildForm newChild = new ChildForm();
                    newChild.MdiParent = this;
                    newChild.Show();
                    newChild.Text = newChild.Text + " " + ++openDocuments;
                    break;
                case "Cascade":
                    this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
                    break;

            }
        }

        private void spWin_Click(object sender, EventArgs e)
        {
            spWin.Text = "Windows is cascade";
            spWin.Text = "Windows is horizontal";

        }

        private void spData_Click(object sender, EventArgs e)
        {

        }
    }
}
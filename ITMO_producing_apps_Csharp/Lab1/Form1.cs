namespace Lab1
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddPolygon(new Point[] { new Point(0, 0),new Point(0, this.Height),new Point(this.Width, 0) });
            Region myRegion = new Region(myPath);
            this.Region = myRegion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Size = new Size(300, 500);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
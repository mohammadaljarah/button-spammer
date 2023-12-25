namespace button_spammer
{
    public partial class Form1 : Form
    {

        private Keys ActivationKey;
        private Keys SpamKey;
        private decimal DelayTime;
        private bool Spam;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartSpamming();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Spam = false;
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            ActivationKey = e.KeyCode;
            textBox1.Text = e.KeyCode.ToString();
            this.ActiveControl = null;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            SpamKey = e.KeyCode;
            textBox2.Text = e.KeyCode.ToString();
            this.ActiveControl = null;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DelayTime = numericUpDown1.Value;

        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{DelayTime}");
        }


        private async void StartSpamming()
        {
            Spam = true;
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
            await Task.Run(async () =>
            {
                while (Spam)
                {
                    this.Invoke(new Action(() =>
                    {
                        System.Windows.Forms.SendKeys.SendWait(SpamKey.ToString());
                    }));
                    Thread.Sleep((int)DelayTime * 1000);
                }
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == ActivationKey) {
                StartSpamming();
            }
        }
    }

}
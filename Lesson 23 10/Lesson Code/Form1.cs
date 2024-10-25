namespace Lesson_Code
{
    public partial class Form1 : Form
    {
        //private List<Person> persons = new List<Person>
        //{
        //    new Person("Tom", "White", 25),
        //    new Person("Fred", "Bluem", 28),
        //};


        public Form1()
        {
            InitializeComponent();
            //listBox1.Items.Add(persons[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Tild");
            //button1.Text = "OK";
            //button1.Enter += button1_Click;
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
            Contact cont = new Contact(textBox1.Text, textBox2.Text);
            listBox1.Items.Add(cont);
            textBox1.Text = "";
            textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Error!");
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class Contact
    {
        public string name { get; set; }
        public string phone { get; set; }

        public Contact(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }

        public override string ToString()
        {
            return $"{name} -- { phone}"; 
        }
    }

    //public class Person
    //{
    //    public string name { get; set; }
    //    public string surName { get; set; }
    //    public int age { get; set; }

    //    public Person(string name, string surName, int age)
    //    {
    //        this.name = name;
    //        this.surName = surName;
    //        this.age = age;
    //    }
    //    public override string ToString()
    //    {
    //        return $"{name} : {surName} : {age}";
    //    }
    //}
}

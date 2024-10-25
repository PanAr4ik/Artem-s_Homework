using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HomeWork_25_10_2024
{
    public partial class Form1 : Form
    {
        private List<Car> cars = new List<Car>();
        private string filePath = "cars.txt";

        public Form1()
        {
            InitializeComponent();

            LoadCarsFromFile();

            foreach (var car in cars)
            {
                listBox1.Items.Add(car);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                Car car = new Car(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                cars.Add(car);
                listBox1.Items.Add(car);

                // Очистка текстовых полей
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveCarsToFile();
        }

        private void SaveCarsToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var car in cars)
                {
                    writer.WriteLine($"{car.mark}|{car.model}|{car.year}|{car.millage}");
                }
            }
            MessageBox.Show("Cars have been saved to file.");
        }

        private void LoadCarsFromFile()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var carData = line.Split('|');
                        if (carData.Length == 4)
                        {
                            Car car = new Car(carData[0], carData[1], carData[2], carData[3]);
                            cars.Add(car);
                        }
                    }
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

    public class Car
    {
        public string mark { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string millage { get; set; }

        public Car(string mark, string model, string year, string millage)
        {
            this.mark = mark;
            this.model = model;
            this.year = year;
            this.millage = millage;
        }

        public override string ToString()
        {
            return $"{mark} -- {model} | {year}y. | {millage}km";
        }
    }
}

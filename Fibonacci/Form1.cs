using System;
using System.Windows.Forms;

namespace Fibonacci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // اتصال رویداد TextChanged به textBox1
            textBox1.TextChanged += textBox1_TextChanged;
        }

        // تابع بازگشتی برای محاسبه عدد فیبوناچی
        private int Fibonacci(int n)
        {
            // اطمینان از برگشت صحیح برای n = 0 و n = 1
            if (n == 0) return 0;
            if (n == 1) return 1;

            // برای مقادیر بزرگتر از 1
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        // رویداد TextChanged برای TextBox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int limit;
                // بررسی مقدار وارد شده برای تبدیل به عدد صحیح
                if (int.TryParse(textBox1.Text, out limit) && limit >= 0)
                {
                    // تست عدد فیبوناچی برای ورودی
                    int result = Fibonacci(limit);
                    label1.Text = $"عدد فیبوناچی برای {limit} برابر است با: {result}";
                }
                else if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    label1.Text = "لطفاً یک عدد وارد کنید.";
                }
                else
                {
                    label1.Text = "لطفاً یک عدد معتبر وارد کنید.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

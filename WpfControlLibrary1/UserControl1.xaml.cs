using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlLibrary1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Storyboard storyboard = new Storyboard();
        public static readonly DependencyProperty GetMyValueProperty =
          DependencyProperty.Register("GetMyValue", typeof(string),
          typeof(UserControl1), new UIPropertyMetadata(string.Empty));
        public string GetMyValue
        {
            get { return (string)GetValue(GetMyValueProperty); }
            set { SetValue(GetMyValueProperty, value); }
        }
        public UserControl1()
        {
            InitializeComponent();
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 150;
            da.Duration = new Duration(TimeSpan.FromSeconds(2));
            strukturaProjekta.BeginAnimation(TreeView.WidthProperty, da);
            listView.BeginAnimation(ListView.WidthProperty, da);
        }
      
        public static readonly DependencyProperty SetTextProperty =
       DependencyProperty.Register("SetText", typeof(string), typeof(UserControl1), new
          PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged)));

        public string SetText
        {
            get { return (string)GetValue(SetTextProperty); }
            set { SetValue(SetTextProperty, value); }
        }

        private static void OnSetTextChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            UserControl1 UserControl1Control = d as UserControl1;
            UserControl1Control.OnSetTextChanged(e);
        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            txtEditor.AppendText(e.NewValue.ToString());
        }


        public TreeView UserControlStrukturaProjekta
        {
            get { return strukturaProjekta; }
            set { strukturaProjekta = value; }
        }
        public RichTextBox richText
        {
            get { return txtEditor; }
            set { richText = value; }
        }

        public event EventHandler OnMethodSelect;

		private void listView_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            
            var item = (sender as ListView).SelectedItem;
			if (item != null)
			{
				txtEditor.Document.Blocks.Clear();
				MyItem myItem = (MyItem)item;
				if (myItem.Id == 1)
				{
					txtEditor.AppendText($" listView.Items.Clear(); var item = (e.NewValue as TreeViewItem);strukturaProjekta.Tag = item if (item.Items.Count == 0");
				}
				if (myItem.Id == 2)
				{
					txtEditor.AppendText($"var item = (sender as ListView).SelectedItem;" + "if (item != null)");
				}
				if (myItem.Id == 3)
				{
					txtEditor.AppendText($"int main()\n {{\n cout << 'Hello, World!'; \n return 0;\n}}\n");
				}
				if (myItem.Id == 4)
				{
					txtEditor.AppendText($" static void Main() {{\n Console.WriteLine('Hello World!');\n }}");
				}
				if (myItem.Id == 5)
				{
					txtEditor.AppendText($"public MainWindow()\n{{\nInitializeComponent();\n}}\n");
				}
				if (myItem.Id == 6)
				{
					txtEditor.AppendText($"InitializeComponent();\n{{\n}}\n");
				}

				if (myItem.Id == 7)
				{
					txtEditor.AppendText($"public Settings() {{\n}}");
				}
				OnMethodSelect?.Invoke(this, e);
                DoubleAnimation da = new DoubleAnimation();
                da.From = 0;
                da.To = 500;
                da.Duration = new Duration(TimeSpan.FromSeconds(2));
                strukturaProjekta.BeginAnimation(TreeView.WidthProperty, da);
            }
		}
		public event EventHandler OnFileSelect;

		private void strukturaProjekta_SelectedItemChange(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var item = (e.NewValue as TreeViewItem);
			OnFileSelect?.Invoke(this, e);
		    //listView.Items.Clear();
			//txtEditor.Document.Blocks.Clear();
			if (item == null)
			{

			}
			else
			{


				strukturaProjekta.Tag = item;
				if (item.Items.Count == 0)
				{
					string name = item.Header.ToString();
					if (name.Contains("Main.cs"))
					{
						txtEditor.AppendText($" using System;\n namespace HelloWorld\n {{\n class Hello\n {{\n static void Main()\n{{\n Console.WriteLine('Hello World!');\n }}\n }}\n }}");
						this.listView.Items.Add(new MyItem { Id = 4, Metoda = " static void Main()" });

					}
					else if (name.Contains("MainWindow.cs"))
					{
						txtEditor.AppendText($"using System.Windows;\n using System.Windows.Controls;\n namespace IDE\n {{\n public partial class MainWindow : Window\n{{\npublic MainWindow()\n{{\nInitializeComponent();\n}}");
						this.listView.Items.Add(new MyItem { Id = 5, Metoda = "MainWindow()" });
						this.listView.Items.Add(new MyItem { Id = 6, Metoda = "InitializeComponent()" });
					}
					else if (name.Contains("Settings.cs"))
					{
						txtEditor.AppendText($"namespace IDE.Properties {{ \ninternal sealed partial class Settings {{ \npublic Settings() {{ \n}}\n");
						this.listView.Items.Add(new MyItem { Id = 7, Metoda = "Settings()" });
					}
					else if (name.Contains("Main.cpp"))
					{
						txtEditor.AppendText($"#include <iostream>\n using namespace std;\n int main()\n {{\n cout << 'Hello, World!';\n return 0;\n }});");
						this.listView.Items.Add(new MyItem { Id = 3, Metoda = "int main()" });
					}
				}
			}
		}

        private void txtEditor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;



        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Collapsed;
            MyItem selected = (MyItem)this.listView.SelectedItem;
            String input = InputTextBox.Text;
            this.listView.Items.Remove(this.listView.SelectedItem);
            this.listView.Items.Add(new MyItem { Id = selected.Id, Metoda = input });

            InputTextBox.Text = String.Empty;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            InputTextBox.Text = String.Empty;
        }
    }
    public class MyItem
	{
		public int Id { get; set; }

		public string Metoda { get; set; }
	}


}

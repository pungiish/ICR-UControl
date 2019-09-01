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
		TreeViewItem tviI = new TreeViewItem() { Header = "Hiter Projekt", HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch };
		TreeViewItem tviIA = new TreeViewItem() { Header = "Main.cs", HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch };
		TreeViewItem tviIB = new TreeViewItem() { Header = "Main.cpp", HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch };
		public UserControl1()
        {
            InitializeComponent();
        }

		public ItemCollection UserControlStrukturaProjekta
		{
			get { return strukturaProjekta.Items; }
			set { strukturaProjekta.ItemsSource = value; }
		}
		public string setText
		{
			set
			{
				txtEditor.Document.Blocks.Clear();
				txtEditor.AppendText(value);
			}
		}

		public void UstvariProjekt()
		{
			strukturaProjekta.Items.Add(tviI);
			strukturaProjekta.Items.Add(tviIA);
			strukturaProjekta.Items.Add(tviIB);
		}

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
			}
		}

		private void strukturaProjekta_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			listView.Items.Clear();
			txtEditor.Document.Blocks.Clear();
			var item = (e.NewValue as TreeViewItem);
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

	}
	public class MyItem
	{
		public int Id { get; set; }

		public string Metoda { get; set; }
	}


}

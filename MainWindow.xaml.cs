using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pizzarendelo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ListboxInit();
    }

    private void ListboxInit()
    {
        List<string> list = ["Margherita", "Sonkás", "Hawaii", "Négy sajtos", "Magyaros"];
        foreach (var i in list)
        {
            Lb.Items.Add(i);
        }
    }
    
    private void GetIndex0()
    {
        var lbi = (ListBoxItem)
            (Lb.ItemContainerGenerator.ContainerFromIndex(0));
        Label.Content = lbi.Content.ToString();
    }

    private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
    {
        if (!Lb.Items.Contains(TxtAdd.Text) && TxtAdd.Text != "")
            Lb.Items.Add(TxtAdd.Text);
    }

    private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
    {
        Lb.Items.Remove(Lb.SelectedItems[0]);
    }

    private void BtnOrder_OnClick(object sender, RoutedEventArgs e)
    {
        GetIndex0();
    }
}
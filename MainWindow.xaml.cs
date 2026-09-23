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
    private List<string> sizes = ["kicsi", "közepes", "nagy"];
    public MainWindow()
    {
        InitializeComponent();
        ListboxInit();
    }

    private void ListboxInit()
    {
        List<string> list1 = ["Margherita", "Sonkás", "Hawaii", "Négy sajtos", "Magyaros"];
        foreach (var i in list1)
        {
            Lb.Items.Add(i);
        }
    }
    
    private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
    {
        RefreshError();
        if (!Lb.Items.Contains(TxtAdd.Text) && TxtAdd.Text != "")
            Lb.Items.Add(TxtAdd.Text);
    }

    private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
    {
        RefreshError();
        if (Lb.SelectedItems.Count == 0) return;
        Lb.Items.Remove(Lb.SelectedItems[0]);
    }

    private void BtnOrder_OnClick(object sender, RoutedEventArgs e)
    {
        if (Lb.SelectedItems.Count == 0)
        {
            LabelError.Content = "Valasszon pizzat!";
            return;
        }
        RefreshError();
        Label.Content = Lb.SelectedItems[0];
        if (sizes.Contains(TxtSize.Text))
        {
            var selectedPizza = Lb.SelectedItems[0] + " - " + TxtSize.Text;; 
            LbOrder.Items.Add(selectedPizza);
            
            LNum.Content = LbOrder.Items.Count;
        }
        else
        {
            LabelSizeError.Content = "Elfogadott méretek:  kicsi - közepes - nagy";
        }
    }

    private void BtnDeleteOrder_OnClick(object sender, RoutedEventArgs e)
    {
        RefreshError();
        if (LbOrder.SelectedItems.Count == 0) return;
        LbOrder.Items.Remove(LbOrder.SelectedItems[0]);
    }
    
    private void BtnDeleteAll_OnClick(object sender, RoutedEventArgs e)
    {
        RefreshError();
        LbOrder.Items.Clear();
        LNum.Content = LbOrder.Items.Count;
    }

    private void RefreshError()
    {
        LabelError.Content = "";
        LabelSizeError.Content = "";
    }
}
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
    private List<string> _sizes = ["kicsi", "közepes", "nagy"];
    public MainWindow()
    {
        InitializeComponent();
        ListboxInit();
    }

    private void ListboxInit()
    {
        List<string> pizzas = ["Margherita", "Sonkás", "Hawaii", "Négy sajtos", "Magyaros"];
        foreach (var i in pizzas)
        {
            Lb.Items.Add(i);
        }
    }
    
    private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
    {
        if (TxtAdd.Text.Length == 0)
        {
            LabelError.Content = "Üres nevű pizzát nem lehet hozzáadni!";
            return;
        }
        RefreshError();
        if (!Lb.Items.Contains(TxtAdd.Text))
            Lb.Items.Add(TxtAdd.Text);
        else
        {
            LabelError.Content = "Ez a pizza mar létezik!";
        }
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
            LabelError.Content = "Válasszon pizzát!";
            return;
        }
        RefreshError();
        Label.Content = Lb.SelectedItems[0];
        if (_sizes.Contains(TxtSize.Text))
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
    
    private void Search_OnClick(object sender, RoutedEventArgs e)
    {
        if (TxtSearch.Text.Length == 0)
        {
            LabelError.Content = "A kereső üres!";
            return;
        }
        RefreshError();
        
        string result = "";
        int x = 0;
        foreach (var item in Lb.Items)
        {
            if (item.ToString()!.Contains(TxtSearch.Text))
            {
                if (x == 0)
                {
                    result = item.ToString()!;
                    x++;
                }
                else
                {
                    result += $", {item}";
                }
            }
        }

        MessageBox.Show(result != "" ? result : "Nincs ilyen pizza a kínálatunkban.", "Keresés eredménye",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void RefreshError()
    {
        LabelError.Content = "";
        LabelSizeError.Content = "";
    }
}
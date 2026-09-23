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
    private List<string> pizzas = ["Margherita", "Sonkás", "Hawaii", "Négy sajtos", "Magyaros"];
    private List<string> ordered = [];
    public MainWindow()
    {
        InitializeComponent();
        Lb.ItemsSource = pizzas;
        LbOrder.ItemsSource = ordered;
    }
    
    private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
    {
        if (TxtAdd.Text.Length == 0)
        {
            LabelError.Content = "Üres nevű pizzát nem lehet hozzáadni!";
            return;
        }
        RefreshError();
        if (!pizzas.Contains(TxtAdd.Text))
        {
            pizzas.Add(TxtAdd.Text);
            Lb.Items.Refresh();
        }
        else
        {
            LabelError.Content = "Ez a pizza mar létezik!";
        }
    }

    private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
    {
        RefreshError();
        if (Lb.SelectedItems.Count == 0) return;
        pizzas.Remove((string)Lb.SelectedItem);
        Lb.Items.Refresh();
    }

    private void BtnOrder_OnClick(object sender, RoutedEventArgs e)
    {
        if (Lb.SelectedItems.Count == 0)
        {
            LabelError.Content = "Válasszon pizzát!";
            return;
        }
        RefreshError();
        if (_sizes.Contains(TxtSize.Text))
        {
            var selectedPizza = Lb.SelectedItem + " - " + TxtSize.Text;; 
            ordered.Add(selectedPizza);
            LbOrder.Items.Refresh();
            
            LNum.Content = ordered.Count;
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
        ordered.Remove((string)LbOrder.SelectedItem);
        LbOrder.Items.Refresh();
        LNum.Content = ordered.Count;
    }
    
    private void BtnDeleteAll_OnClick(object sender, RoutedEventArgs e)
    {
        RefreshError();
        ordered.Clear();
        LbOrder.Items.Refresh();
        LNum.Content = ordered.Count;
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
            if (item.ToString()!.Contains(TxtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
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
            MessageBoxButton.OK, MessageBoxImage.None);
    }

    private void RefreshError()
    {
        LabelError.Content = "";
        LabelSizeError.Content = "";
    }
    
    private void lb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if(Lb.SelectedItem != null)
            Label.Content = Lb.SelectedItem;
    }
}
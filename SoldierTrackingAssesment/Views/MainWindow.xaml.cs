using Infra.SoldierTrackingAssesment;
using System.Windows;

namespace SoldierTrackingAssesment;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly SoldierTrackingAssesmentContext dbContext;

    public MainWindow(SoldierTrackingAssesmentContext dbContext)
    {
        this.dbContext = dbContext;
        InitializeComponent();
        GetSoldiers();
    }

    private void GetSoldiers()
    {
        var soldiers = dbContext.Soldiers.ToList();
        SoldierDataGrid.ItemsSource = soldiers;
    }
}
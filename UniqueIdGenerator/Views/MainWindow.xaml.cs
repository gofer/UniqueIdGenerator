using System.Text;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UniqueIdGenerator.ViewModels;

namespace UniqueIdGenerator.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static void SetSelectAllHandlerForTextBox(TextBox textBox)
    {
        textBox.GotFocus += (_, __) => textBox.SelectAll();

        textBox.PreviewMouseDown += (_, e) =>
        {
            if (textBox.IsFocused)
            {
                return;
            }

            e.Handled = true;
            textBox.Focus();
        };
    }

    public MainWindow(MainWindowViewModel viewModel)
    {
        ArgumentNullException.ThrowIfNull(viewModel);

        InitializeComponent();

        this.DataContext = viewModel;

        SetSelectAllHandlerForTextBox(this.GuidTextBox);
        SetSelectAllHandlerForTextBox(this.TextIdTextBox);
    }
}
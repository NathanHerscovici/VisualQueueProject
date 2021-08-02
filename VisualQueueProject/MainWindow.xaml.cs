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

namespace VisualQueueProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int PanelIndex { get; private set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CreateNewButton()
        {
            Button newButton = new Button();
            newButton.Content = "test" + PanelIndex++.ToString();
            newButton.Click += new RoutedEventHandler(PanelClick);
            uxStackPanel.Children.Insert(0, newButton );
        }

        private void uxSaveButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewGrid();
        }

        private void CreateNewGrid()
        {
            Grid grid = new Grid();
            grid.ShowGridLines = false;
            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            RowDefinition row1 = new RowDefinition();
            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);
            grid.RowDefinitions.Add(row1);
            Button newButton = new Button();
            newButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            //newButton.Width = 200;
            newButton.Content = "test";
            CheckBox check = new CheckBox();
            check.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(newButton, 1);
            Grid.SetColumn(check, 0);
            grid.Children.Add(newButton);
            grid.Children.Add(check);
            uxStackPanel.Children.Add(grid);
        }

        private void PanelClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            uxStackPanel.Children.Remove(button);
        }
    }
}

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
            Grid grid = new Grid(); //Create new grid
            grid.ShowGridLines = false; //Turn the visible grid lines off
            grid.HorizontalAlignment = HorizontalAlignment.Stretch; //Have the grid stretch the entire area it has horizontally. 
            ColumnDefinition col1 = new ColumnDefinition(); //Create a new Column object.
            col1.Width = GridLength.Auto;
            ColumnDefinition col2 = new ColumnDefinition(); //Create a second new Column object.
            RowDefinition row1 = new RowDefinition(); //Create a new Row object.
            row1.Height = new GridLength(100); //Set the height of the row.
            grid.ColumnDefinitions.Add(col1); //Add the first column to the grid.
            grid.ColumnDefinitions.Add(col2); //Add the second column to the grid.
            grid.RowDefinitions.Add(row1); //Add the row to the grid.

            Grid grid2 = new Grid(); //Create a new grid to house the title and descriptions.
            grid2.ShowGridLines = false;
            grid2.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid2.VerticalAlignment = VerticalAlignment.Stretch;
            ColumnDefinition g2Col1 = new ColumnDefinition();
            g2Col1.Width = GridLength.Auto;
            ColumnDefinition g2Col2 = new ColumnDefinition();
            RowDefinition g2Row1 = new RowDefinition();
            RowDefinition g2Row2 = new RowDefinition();
            grid2.ColumnDefinitions.Add(g2Col1);
            grid2.ColumnDefinitions.Add(g2Col2);
            grid2.RowDefinitions.Add(g2Row1);
            grid2.RowDefinitions.Add(g2Row2);

            TextBox title = new TextBox(); //Create a new text box object.
            title.IsReadOnly = true; //Set the read only variable to true so you cannot type in the text box.
            title.Text = uxTitle.Text; //Set the text.
            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 1);

            TextBox desc = new TextBox();
            desc.IsReadOnly = true;
            desc.Text = uxDescription.Text;
            Grid.SetRow(desc, 1);
            Grid.SetColumn(desc, 1);

            Label titleLbl = new Label();
            titleLbl.Content = "Title:";
            Grid.SetRow(titleLbl, 0);
            Grid.SetColumn(titleLbl, 0);
            grid2.Children.Add(titleLbl);

            Label descLbl = new Label();
            descLbl.Content = "Description:";
            Grid.SetRow(descLbl, 1);
            Grid.SetColumn(descLbl, 0);
            grid2.Children.Add(descLbl);

            grid2.Children.Add(title);
            grid2.Children.Add(desc);

            CheckBox check = new CheckBox(); //Create a new checkbox.
            check.HorizontalAlignment = HorizontalAlignment.Center; //Allign the text box in the center horizontally.
            check.VerticalAlignment = VerticalAlignment.Center; //Allign the text box in the center vertically.
            check.Click += new RoutedEventHandler(CheckClick); //Create a new event for when the check box is clicked.
            Grid.SetColumn(grid2, 1); //Set the text box to appear in the second column.
            Grid.SetColumn(check, 0); //Set the check box to appear in the second column.
            grid.Children.Add(grid2); //Add the text box to the grids children.
            grid.Children.Add(check); //Add the check box to the grids children.
            uxStackPanel.Children.Add(grid); //Add the grid to the stack panel.
        }

        private void CheckClick(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            uxStackPanel.Children.Remove((Grid)box.Parent);
            Console.WriteLine(uxStackPanel.Children.IndexOf(box));
        }

        private void PanelClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            uxStackPanel.Children.Remove(button);
        }

        private void uxTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if(text.Text == "")
                text.Text = "Enter the title of the event..";
        }

        private void uxDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if(text.Text == "")
                text.Text = "Enter the description of the event..";
        }

        private void uxTitle_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if(text.Text == "Enter the title of the event.." || text.Text == "Enter the description of the event..")
                text.Text = "";
        }

        private void uxTitle_LoseFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}

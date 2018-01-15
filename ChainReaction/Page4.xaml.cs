using ChainReaction.Common;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.Media;
using Windows.UI;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace ChainReaction
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page4 : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();


        struct node
        {
            public int x;
            public int y;

        };

        int rows, columns, players;
        int x, y;
        int[] flag = new int[15];
        int[,] a;
        int[,] b;
        int turn = 0;
        int w = 1;

        bool gameEnd = false;
        public Page4()
        {


            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
          //  this.NavigationCacheMode =  Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

           // this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
           // this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        void printMatrix(int[,] a, int[,] b, int r, int c)
        {
            foreach (Button bt in buttonCanvas.Children)
            {
                int i, j;
                i = Convert.ToInt32(bt.Name.Split(',')[1]);
                j = Convert.ToInt32(bt.Name.Split(',')[2]);
                if(a[i,j]!=0)
                bt.Content = "" + a[i, j];//+"," + b[i, j];
                else
                    bt.Content = "";

                if (b[i, j] == 0)

                    bt.Background = new SolidColorBrush(Windows.UI.Colors.Transparent);

                if (b[i, j] == 1)
                    bt.Background = new SolidColorBrush(Color.FromArgb(255, 242, 177, 121));

                if (b[i, j] == 2)
                    bt.Background = new SolidColorBrush(Color.FromArgb(255, 246, 94, 59));

                if (b[i, j] == 3)
                    bt.Background = new SolidColorBrush(Color.FromArgb(255, 237, 197, 63));

                if (b[i, j] == 4)
                    bt.Background = new SolidColorBrush(Color.FromArgb(255, 62, 57, 51));

                if (b[i, j] == 5)
                    bt.Background = new SolidColorBrush(Windows.UI.Colors.Orange);

                if (b[i, j] == 6)
                    bt.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);

                if (b[i, j] == 7)
                    bt.Background = new SolidColorBrush(Windows.UI.Colors.Magenta);

                if (b[i, j] == 8)
                    bt.Background = new SolidColorBrush(Windows.UI.Colors.Cyan);

            }


        }



        bool checkIsValid(int x, int y, int p)
        {
            if (b[x, y] == p || b[x, y] == 0)
                return true;
            else
                return false;
        }




        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);


            int k;
            k = 1;
           // players = 2;
              string msg = e.Parameter.ToString();
             players = Convert.ToInt32(msg.Split(',')[0]);
            //int k = Convert.ToInt32(msg.Split(',')[1]);




            if (k == 1)
            {
                rows = 5;
                columns = 5;

                int[] r = new int[5]; //{5,55,105,155,255,305};
                r[0] = 120; r[1] = 200; r[2] = 280; r[3] = 357; r[4] = 434;

                int[] c = new int[5];
                c[0] = 8; c[1] = 86; c[2] = 165; c[3] = 243; c[4] = 322;


                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        Button btn = new Button();
                        btn.Name = "btn," + j + "," + i;
                        btn.MinHeight = 10;
                        btn.MinWidth = 10;
                        btn.Height = 88;
                        btn.Width = 70;
                        btn.FontFamily = new FontFamily("Consolas");
                        btn.FontSize = 30;
                        //btn.Margin = new Thickness(x, y, 0, 0);
                        btn.Margin = new Thickness(c[i], r[j], 0, 0);
                        btn.BorderThickness = new Thickness(0);
                        //BorderBrush.SetValue(brdr,Windows.UI.Colors.Aqua);
                        //    brdr.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Azure);
                        buttonCanvas.Children.Add(btn);
                        btn.Click += buttonTapHandler;

                    }
                }
            }




            a = new int[20, 20];
            b = new int[20, 20];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    a[i, j] = 0;
                    b[i, j] = 0;
                }



            for (int i = 1; i <= players; i++)
                flag[i] = 1;



        }




        public bool checkifplayerloses(int p, int r, int c)
        {
            bool flag = true;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                    if (b[i, j] == p)
                    {
                        flag = false;
                        break;
                    }
                if (flag == false)
                    break;
            }

            return flag;

        }



        int capacity(int x, int y, int r, int c)
        {
            if ((x == 0 && y == 0) || (x == 0 && y == c - 1) || (x == r - 1 && y == 0) || (x == r - 1 && y == c - 1))
                return 2;
            else if (x >= 1 && x < r - 1 && y >= 1 && y < c - 1)
                return 4;
            else if ((x == 0 || x == r - 1) && (y != 0 && y != c - 1))
                return 3;
            else
                return 3;

        }


        void playthechance(int x, int y, int r, int c, int p)
        {
            Queue<node> q = new Queue<node>();
            node ne;
            ne.x = x;
            ne.y = y;
            q.Enqueue(ne);
            a[x, y]++;
            if (a[x, y] == 1)
                b[x, y] = p;
            // printMatrix(a, b, r, c);



            while (q.Count != 0)
            {

                bool breakflag = false;

                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                        if (b[i, j] != p && b[i, j] != 0)
                        {
                            breakflag = true;
                            break;
                        }
                    if (breakflag)
                        break;
                }

                if (!breakflag)
                    break;




                node curr;
                curr = q.Peek();
                q.Dequeue();
                if (a[curr.x, curr.y] >= capacity(curr.x, curr.y, r, c))
                {
                    a[curr.x, curr.y] = 0;
                    b[curr.x, curr.y] = 0;
                    if (curr.x >= 1)
                    {
                        node nu;
                        nu.x = curr.x - 1;
                        nu.y = curr.y;
                        q.Enqueue(nu);
                        a[nu.x, nu.y]++;
                        b[nu.x, nu.y] = p;
                    }
                    if (curr.x < r - 1)
                    {
                        node nu;
                        nu.x = curr.x + 1;
                        nu.y = curr.y;
                        q.Enqueue(nu);
                        a[nu.x, nu.y]++;
                        b[nu.x, nu.y] = p;


                    }
                    if (curr.y >= 1)
                    {
                        node nu;
                        nu.y = curr.y - 1;
                        nu.x = curr.x;
                        q.Enqueue(nu);
                        a[nu.x, nu.y]++;
                        b[nu.x, nu.y] = p;
                    }
                    if (curr.y < c - 1)
                    {
                        node nu;
                        nu.y = curr.y + 1;
                        nu.x = curr.x;
                        q.Enqueue(nu);
                        a[nu.x, nu.y]++;
                        b[nu.x, nu.y] = p;

                    }



                }
            }

            printMatrix(a, b, r, c);



        }




        private void buttonTapHandler(object sender, RoutedEventArgs e)
        {
            turn++;
            Button source = (Button)sender;

            x = Convert.ToInt32(source.Name.Split(',')[1]);
            y = Convert.ToInt32(source.Name.Split(',')[2]);

            //   enter.Text = "Player  " + w + "  Chance  ";
            if (checkIsValid(x, y, w))
            {
                playthechance(x, y, rows, columns, w);


                for (int i = 1; i <= players; i++)
                {
                    if (turn > players && checkifplayerloses(i, rows, columns))
                    {
                        flag[i] = 0;
                    }
                }


                int count = 0;
                for (int j = 1; j <= players; j++)
                    if (flag[j] == 1)
                        count++;

                if (count == 1)
                {
                    gameEnd = true;
                    Frame.Navigate(typeof(Page2), w);

                    // go to new xaml page
                }

                int chance = w;
                for (int i = w + 1; i <= players; i++)
                {
                    if (flag[i] == 1)
                    {
                        chance = i;
                        break;
                    }

                }

                if (chance == w)
                {

                    for (int i = 1; i < w; i++)
                    {
                        if (flag[i] == 1)
                        {
                            chance = i;
                            break;
                        }
                    }
                }


                w = chance;

                if (w == 1)
                    foreach (Button bt in buttonCanvas.Children)
                    {
                        int i, j;
                        i = Convert.ToInt32(bt.Name.Split(',')[1]);
                        j = Convert.ToInt32(bt.Name.Split(',')[2]);
                      //  bt.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Blue);
                        brdr.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 242, 177, 121));
                    }

                if (w == 2)
                    foreach (Button bt in buttonCanvas.Children)
                    {
                        int i, j;
                        i = Convert.ToInt32(bt.Name.Split(',')[1]);
                        j = Convert.ToInt32(bt.Name.Split(',')[2]);
                      //  bt.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                        brdr.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 246, 94, 59));
                    }

                if (w == 3)
                    foreach (Button bt in buttonCanvas.Children)
                    {
                        int i, j;
                        i = Convert.ToInt32(bt.Name.Split(',')[1]);
                        j = Convert.ToInt32(bt.Name.Split(',')[2]);
                       // bt.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                        brdr.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 237, 197, 63));
                    }
                if (w == 4)
                    foreach (Button bt in buttonCanvas.Children)
                    {
                        int i, j;
                        i = Convert.ToInt32(bt.Name.Split(',')[1]);
                        j = Convert.ToInt32(bt.Name.Split(',')[2]);
                       // bt.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);
                        brdr.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 62, 57, 51));
                    }


            }
            else
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
         //   this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            Frame.Navigate(typeof(BlankPage1));
        }


    }
}

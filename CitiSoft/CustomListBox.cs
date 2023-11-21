﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class CustomListBox : Panel
    {

        public CustomListBox()
        {
            InitializeComponent ();
        }
        
        public ListBox listBox = new ListBox() { Size = new System.Drawing.Size(150, 90), Location = new System.Drawing.Point(0,0) };
        public Button add = new Button() { Size = new System.Drawing.Size(100, 25), Location = new System.Drawing.Point(155,2), Text="Add" };
        public Button remove = new Button() { Size = new System.Drawing.Size(100, 25), Location = new System.Drawing.Point(155,32), Text= "Remove" };
        public Button clear = new Button() { Size = new System.Drawing.Size(100, 25), Location = new System.Drawing.Point(155, 62), Text= "Clear" };
        public int height = 90, width = 300;
        void InitializeComponent() 
        {
            Controls.AddRange(new Control[] {listBox,add,remove,clear});
            Size = new System.Drawing.Size(width, height);
        }

        public void setHeightWidth(int width, int height)
        {
            Size = new System.Drawing.Size(width, height);
            listBox.Size=new System.Drawing.Size(width-150, height);
            add.Left=width-145;
            remove.Left = width - 145;
            clear.Left = width - 145;
        }

    }
}

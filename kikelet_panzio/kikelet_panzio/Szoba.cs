﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace kikelet_panzio
{
    internal class Szoba
    {
        int szobaszam;
        int ferohely;
        int arperfo;
        public int Szobaszam { get => szobaszam; }
        public int Ferohely { get => ferohely; set => ferohely = value; }
        public int Arperfo { get => arperfo; set => Arperfo = value; }
        public Szoba(int szobaszam, int ferohely, int arperfo)
        {
            this.szobaszam = szobaszam;
            this.ferohely = ferohely;
            this.arperfo = arperfo;
        }
        public Szoba(string sor)
        {
            string[] adatok = sor.Split(';');
            szobaszam = Convert.ToInt32(adatok[0]);
            ferohely = Convert.ToInt32(adatok[1]);
            arperfo = Convert.ToInt32(adatok[2]);
        }
        public int Ar()
        {
            return 0; //ideiglenes
        }
        public int Kedvezmenyes()
        {
            return Convert.ToInt32(Ar() * 0.97d);
        }
    }
}

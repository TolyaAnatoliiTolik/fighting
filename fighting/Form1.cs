using fighting.Enites;
using fighting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fighting
{

    

    public partial class Form1 : Form
    {

        public Entity player;
        public Image dwarfSheet;
        public Image gladiatorSheet;

        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);


            Init();
        }


        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            player.dirX = 0;
            player.dirY = 0;
            player.isMoving = false;
            player.SetAnimationConfiguration(0);
        }



        public void OnPress(object sender, KeyEventArgs e)                   //управление персонажем
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -1;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(1);
                    break;
                case Keys.S:
                    player.dirY = 1;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(1);
                    break;
                case Keys.A:
                    player.dirX = -1;
                    player.isMoving = true;
                    player.flip = -1;
                    player.SetAnimationConfiguration(1);
                    break;
                case Keys.D:
                    player.dirX = 1;
                    player.isMoving = true;
                    player.flip = 1;
                    player.SetAnimationConfiguration(1);
                    break;
                case Keys.Space:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.isMoving = false;
                    player.SetAnimationConfiguration(2);
                    break;
            }
            
        }



        public void Init()                   //отвечает за иниицаилизацию все игры
        {
            dwarfSheet = new Bitmap(Path.Combine (new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),"Sprites\\Dwarf.png"));


             player = new Entity(100, 100, Hero.idleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, dwarfSheet);
            timer1.Start();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public void Update(object sender, EventArgs e)
        {
            if (player.isMoving)
                player.Move();
            Invalidate();
        }



        private void OnePaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            player.PlayAnimation(g);

        }
    }
}

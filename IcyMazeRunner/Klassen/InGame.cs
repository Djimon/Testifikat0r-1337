﻿using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IcyMazeRunner.Klassen;
using SFML.Audio;

namespace IcyMazeRunner.Klassen
{
    class InGame : GameStates
    {
        /* ~~~~~~~~ VARIABLEN UND KONSTANTEN ~~~~~~~~*/

        int level = 0;
        GameTime time = new GameTime();

        Map map;
        View view;

        Player Runner;

        Sprite backGround;
        Sprite Fog_of_War;
        
        
        /* ~~~~ Initialisierung des Spiels ~~~~ */
        public void initialize()
        {
           

            time = new GameTime();
            time.start();
            view = new View(new FloatRect(0, 0, 1062, 720));
            
            backGround = new Sprite(new Texture("Texturen/Map/background.png"));
            backGround.Position = new Vector2f(0, 0);

            Fog_of_War = new Sprite(new Texture("Texturen/Map/Fog_of_War.png"));
            Fog_of_War.Position = new Vector2f(0, 0);
            
          
        }

        /* ~~~~ Inhalte laden ~~~~ */
        public void loadContent(){
          
            /*
            Map-Positionen:
            Map_tutorial (190,0)
            Map_2 (2263, 3336)
             */



            // Levelzuweisung

            switch (level)
            {
                case 0:
                    map = new Map(new Bitmap("Texturen/Map/Map_tutorial.bmp"));
                    Runner = new Player(new Vector2f(280, 100), map);

                    break;

                case 1:
                    map = new Map(new Bitmap("Texturen/Map_1.bmp"));
                    Runner = new Player(new Vector2f(0, 0), map);
                    break;
                    
                case 2:
                    map = new Map(new Bitmap("Texturen/Map_2.bmp"));
                    Runner = new Player(new Vector2f(2263,3336), map);
                    break;

            }

          
            //        hier Fallen und Hindernisse laden???
            //         ziel?
           

            
        }


        /* ~~~~ Update ~~~~ */
        public EGameStates update(GameTime gametime)
        {


            time.update();

            if (level != level) // Kollision mit Treppe= true
            {
                level++;
                Program.game.handleGameState();
                return EGameStates.inGame;
            }

            if (level == 15)
            {
                view = new View(new FloatRect(0, 0, 1062, 720));
                return EGameStates.gameWon;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.O))
            {
                view=new View(new FloatRect(0, 0, 1062, 720));
                return EGameStates.gameWon;
            }

            Runner.update(time);
            // bewegliche Mauern (if-Abfrage), Kollision mit Schalter
            // später: Bewegung der Gegner, Geschosse, Anzeigen, Kollision

            backGround.Position = new Vector2f(view.Center.X - 531, view.Center.Y - 360);
            Fog_of_War.Position = new Vector2f(view.Center.X - 531, view.Center.Y - 360);
            view.Move(new Vector2f((Runner.getXPosition() + (Runner.getWidth() / 2)), (Runner.getYPosition() + (Runner.getHeigth() / 2))) - view.Center);


            return EGameStates.inGame;
        }

        public void draw(RenderWindow win)
        {
            win.Draw(backGround);
            win.SetView(view);
            map.draw(win);
            Runner.draw(win);
            win.Draw(Fog_of_War);
        }
        
    }
}

﻿using System;
using System.Diagnostics;
using System.Threading;
using SFML.Graphics;
using SFML.Window;

namespace TCEngine
{
    public class TecnoCampusEngine
    {

        //
        // Members
        //  
        public const uint WINDOW_WIDTH = 1024;
        public const uint WINDOW_HEIGHT = 768;

        private const byte FRAME_RATE = 60;
        private const float FIXED_DELTA_TIME = 1.0f / FRAME_RATE;
        private const float MAX_DELTA_TIME = 5.0f;
        private const int MAX_FRAMES_WITHOUT_RENDERING = 5;

        private RenderWindow m_Window;

        // 
        // Methods
        //
        private void Init()
        {

            VideoMode videoMode = new VideoMode(1024, 768);
            m_Window = new RenderWindow(videoMode, "Game");
            m_Window.SetVerticalSyncEnabled(true);
        }

        private void DeInit()
        {
            m_Window.Dispose();
        }

        private void Update(float _dt)
        {
            m_Window.DispatchEvents();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                m_Window.Close();
            }
        }

        private bool IsAlive()
        {
            return m_Window.IsOpen;
        }

        public void Run(Game _game)
        {
            Debug.Assert(_game != null, "The _game parameter of type Game cannot be null");

            Init();
            _game.Init(m_Window);

            DateTime startGameTime = DateTime.Now;
            int framesWithoutRendering = 0;
            double nextTime = (DateTime.Now - startGameTime).TotalMilliseconds / 1000.0;
            //  nextTime will be 0

            while (IsAlive())
            {
                // DESIGN NOTES
                // We have 3 cases during the update: 
                //    1. The time passed between 2 frames is exactly FIXED_DELTA_TIME
                //    2. The time passed between 2 frames is greater than FIXED_DELTA_TIME
                //    3. The time passed between 2 frames is smaller than FIXED_DELTA_TIME
                double beginFrameTime = (DateTime.Now - startGameTime).TotalMilliseconds / 1000.0;

                // Case 1 -> This check is always false
                // Case 2 -> This check will be true from time to time (when the accumulated time is greater than MAX_DELTA_TIME)
                // Case 3 -> This check is always false
                if ((beginFrameTime - nextTime) > MAX_DELTA_TIME)
                {
                    // We are in Case 2, the game is too slow (it could be because for several reasons), so we "hack" our data in order
                    // to keep updating/rendering the game
                    nextTime = beginFrameTime;
                }

                // Case 1 -> This check is always true
                // Case 2 -> This check is always true
                // Case 3 -> This check is always false
                if (beginFrameTime >= nextTime)
                {
                    // We are in Case 1 or 2

                    nextTime += FIXED_DELTA_TIME; // Update nextTime to the expected next beginFrameTime

                    Update(FIXED_DELTA_TIME);
                    _game.Update(FIXED_DELTA_TIME);

                    // We render the frame only if one of the next two conditions is true:
                    //   - We are in Case 1
                    //   - We are in Case 2, but we already skipped the rendering step durring too many frames in a row
                    if ((beginFrameTime < nextTime) || (framesWithoutRendering >= MAX_FRAMES_WITHOUT_RENDERING))
                    {
                        m_Window.Clear(Color.Black);
                        _game.Draw(m_Window);
                        m_Window.Display();

                        framesWithoutRendering = 0;
                    }
                    else
                    {
                        ++framesWithoutRendering;
                    }
                }
                else
                {
                    // We are in Case 3, the game is too fast, so we need to put him to sleep to avoid wasting the CPU.
                    // This will make the code think that at the beginning of the next frame, we are on Case 1.
                    int sleepTime = (int)(1000.0 * (nextTime - beginFrameTime));
                    if (sleepTime > 0)
                    {
                        Thread.Sleep(sleepTime);
                    }
                }
            }

            _game.DeInit();
            DeInit();
        }
    }
}

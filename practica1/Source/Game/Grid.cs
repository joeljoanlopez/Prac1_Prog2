using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using practica1.Source.Game;
using TCEngine;

namespace TCGame
{
    public class Grid : Drawable
    {

        //
        // Members
        //  
        private const int NUM_COLUMNS = 4;
        private const int NUM_ROWS = 3;

        private LineDrawer m_Lines;
        private List<Item> m_Items;
        private Texture m_BackgroundTexture;
        private Sprite m_BackgroundSprite;


        //
        // Accessors
        //
        public float SlotWidth
        {
            get { return TecnoCampusEngine.WINDOW_WIDTH / (float)NUM_COLUMNS; }
        }

        public float SlotHeight
        {
            get { return TecnoCampusEngine.WINDOW_HEIGHT / (float)NUM_ROWS; }
        }

        public int MaxItems
        {
            get { return NUM_COLUMNS * NUM_ROWS; }
        }

        // 
        // Methods
        //
        public void Init()
        {
            m_BackgroundTexture = new Texture("Data/Textures/Background.jpg");
            m_BackgroundSprite = new Sprite(m_BackgroundTexture);

            m_Items = new List<Item>();

            FillGridLines();
        }

        public void DeInit()
        {
            m_BackgroundTexture.Dispose();
        }

        public void HandleKeyPressed(object _sender, KeyEventArgs _keyEvent)
        {
            if (_keyEvent.Code == Keyboard.Key.A)
            {
                if (HasNullSlot())
                {
                    AddItemAtIndex(NewRandomItem(), GetFirstNullSlot());
                }
                else
                {
                    AddItemAtEnd(NewRandomItem());
                }
            }
            else if (_keyEvent.Code == Keyboard.Key.R)
            {
                RemoveLastItem();
            }
            else if (_keyEvent.Code == Keyboard.Key.N)
            {
                NullAllCoins();
            }
            else if (_keyEvent.Code == Keyboard.Key.V)
            {
                ReverseItems();
            }
            else if (_keyEvent.Code == Keyboard.Key.S)
            {
                RemoveNullSlots();
            }
            else if (_keyEvent.Code == Keyboard.Key.M)
            {
                RemoveAllItems();
            }
            else if (_keyEvent.Code == Keyboard.Key.K)
            {
                NullAllWeapons();
            }
            else if (_keyEvent.Code == Keyboard.Key.O)
            {
                OrderItems();
            }
        }

        private void FillGridLines()
        {
            m_Lines = new LineDrawer(NUM_COLUMNS + NUM_ROWS + 2);

            for (int i = 0; i <= NUM_COLUMNS; ++i)
            {
                m_Lines.AddLine(new Vector2f(i * SlotWidth, 0.0f), new Vector2f(i * SlotWidth, TecnoCampusEngine.WINDOW_HEIGHT), 2.0f, new Color(0, 0, 0, 150));
            }

            for (int i = 0; i <= NUM_ROWS; ++i)
            {
                m_Lines.AddLine(new Vector2f(0.0f, i * SlotHeight), new Vector2f(TecnoCampusEngine.WINDOW_WIDTH, i * SlotHeight), 2.0f, new Color(0, 0, 0, 150));
            }
        }

        public void Update(float _dt)
        {
            for (int i = 0; i < m_Items.Count; ++i)
            {
                int row = i / NUM_COLUMNS;
                int column = i % NUM_COLUMNS;

                Vector2f position = new Vector2f(SlotWidth / 2.0f + SlotWidth * column, SlotHeight / 2.0f + SlotHeight * row);
                Item item = m_Items[i];
                if (item != null)
                {
                    item.Position = position;
                }
            }
        }

        public void Draw(RenderTarget _renderTarget, RenderStates _renderState)
        {
            _renderTarget.Draw(m_BackgroundSprite, _renderState);
            _renderTarget.Draw(m_Lines, _renderState);

            foreach (Item item in m_Items)
            {
                if (item != null)
                {
                    _renderTarget.Draw(item, _renderState);
                }
            }
        }

        private Item NewRandomItem()
        {
            Item[] _randItem =
                { new Bomb(), new Heart(), new Sword(), new Axe(), new Coin(), new Clyde(), new Blinky() };
            Random rand = new Random();
            return _randItem[rand.Next(_randItem.Length)];
        }

        private void RemoveLastItem()
        {
        }

        private void NullAllCoins()
        {
        }

        private void RemoveNullSlots()
        {
        }

        private void RemoveAllItems()
        {
        }

        private void NullAllWeapons()
        {
        }

        private bool HasNullSlot()
        {
            return false;
        }

        private int GetFirstNullSlot()
        {
            return -1;
        }

        private void AddItemAtIndex(Item _item, int _index)
        {
        }

        private void AddItemAtEnd(Item _item)
        {
        }

        private void OrderItems()
        {
        }

        private void ReverseItems()
        {
        }
    }
}

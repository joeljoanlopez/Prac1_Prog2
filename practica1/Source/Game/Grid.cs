using practica1.Source.Game;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
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
        private Window _Window;


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
        public void Init(Window _w)
        {
            m_BackgroundTexture = new Texture("Data/Textures/Background.jpg");
            m_BackgroundSprite = new Sprite(m_BackgroundTexture);
            _Window = _w;
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
            else if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Vector2f _mousePos = (Vector2f)Mouse.GetPosition(_Window);
                DeleteObject(_mousePos);
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

            if (m_Items.Count != 0)
            {
                m_Items.RemoveAt(m_Items.Count - 1);
            }
        }

        private void NullAllCoins()
        {
            Coin _coin = new Coin();
            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i].IsType() == _coin.IsType())
                {
                    m_Items[i] = null;
                }
            }


            //Show list in console
            Console.WriteLine();
            Console.WriteLine("Items List:");
            foreach (var _item in m_Items)
            {
                if (_item != null)
                {

                    Console.WriteLine(_item.IsType());
                }
                else
                {

                    Console.WriteLine("null");
                }
            }
        }

        private void RemoveNullSlots()
        {
            while (HasNullSlot())
            {
                m_Items.RemoveAt(GetFirstNullSlot());
            }

            //Show list in console
            Console.WriteLine();
            Console.WriteLine("Items List:");
            foreach (var _item in m_Items)
            {
                if (_item != null)
                {

                    Console.WriteLine(_item.IsType());
                }
                else
                {

                    Console.WriteLine("null");
                }
            }

        }

        private void RemoveAllItems()
        {
        }

        private void NullAllWeapons()
        {
        }

        private bool HasNullSlot()
        {
            return GetFirstNullSlot() != -1;
        }

        private int GetFirstNullSlot()
        {
            bool found = false;
            int i = 0;
            while (!found && i < m_Items.Count)
            {
                if (m_Items[i] == null) found = true;
                else i++;
            }
            
            return found ? i : -1;
        }

        private void AddItemAtIndex(Item _item, int _index)
        {
            m_Items[_index] = _item;
        }

        private void AddItemAtEnd(Item _item)
        {
            if (m_Items.Count < MaxItems)
            {
                m_Items.Add(_item);
                Console.WriteLine(_item.IsType());
            }
        }

        private void OrderItems()
        {
        }

        private void ReverseItems()
        {
        }

        private void DeleteObject(Vector2f _pos)
        {

        }
    }
}

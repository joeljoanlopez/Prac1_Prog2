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
        }

        public void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
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
            if (m_Items.Count != 0) m_Items.RemoveAt(m_Items.Count - 1);
        }

        private void NullAllCoins()
        {
            Coin _coin = new Coin();
            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i] != null && m_Items[i] is Coin)
                {
                    m_Items[i] = null;
                }
            }
        }

        private void RemoveNullSlots()
        {
            while (HasNullSlot()) m_Items.RemoveAt(GetFirstNullSlot());

        }

        private void RemoveAllItems()
        {
            m_Items.Clear();
        }

        private void NullAllWeapons()
        {
            Weapon _weapon = new Weapon();
            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i] != null && m_Items[i] is Weapon)
                {
                    m_Items[i] = null;
                }
            }  
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
            if (m_Items.Count < MaxItems) m_Items.Add(_item);
            
        }

        private void OrderItems()
        {
            List<Item> aux;
            aux = new List<Item>();

            foreach (var _item in m_Items)
            {
                if (_item is Heart) aux.Add(_item);
            }
            foreach (var _item in m_Items)
            {
                if (_item is Weapon) aux.Add(_item);
            }
            foreach (var _item in m_Items)
            {
                if (_item is Bomb) aux.Add(_item);
            }
            foreach (var _item in m_Items)
            {
                if (_item is Coin) aux.Add(_item);
            }
            foreach (var _item in m_Items)
            {
                if (_item is not Heart && _item is not Weapon && _item is not Bomb && _item is not Coin) aux.Add(_item);
            }

            m_Items = aux;
        }

        private void ReverseItems()
        {
            m_Items.Reverse();
        }

        private void DeleteObject(Vector2f _mousePos)
        {
            Vector2i _coords = GetGridPos(_mousePos);
            int _ListPos = GridToList(_coords);

            Bomb _bomb = new Bomb();
            if (m_Items[_ListPos] != null && m_Items[_ListPos] is Bomb)
            {
                BombExplode(_coords);
            }
            m_Items[_ListPos] = null;
            
        }

        private void BombExplode(Vector2i _pos)
        {
            //Set Bomb Coords
            int _col = _pos.X;
            int _row = _pos.Y;

            //Get other Coords
            int _right = GridToList(new Vector2i(_col + 1, _row));
            int _left = GridToList(new Vector2i(_col - 1, _row));
            int _down = GridToList(new Vector2i(_col, _row + 1));
            int _up = GridToList(new Vector2i(_col, _row - 1));

            //Delete coords
            if (ExistsPos(_right)) m_Items[_right] = null;
            if (ExistsPos(_left)) m_Items[_left] = null;
            if (ExistsPos(_down)) m_Items[_down] = null;
            if (ExistsPos(_up)) m_Items[_up] = null;
        }

        private Vector2i GetGridPos(Vector2f _pos)
        {
            int _rowNum = -1;
            int _colNum = -1;
            int i = 0;

            while (i < NUM_COLUMNS && _colNum == -1)
            {
                if (_pos.X > SlotWidth * i && _pos.X < SlotWidth * (i + 1)) _colNum = i;
                else i++;
            }

            i = 0;
            while (i < NUM_ROWS && _rowNum == -1)
            {
                if (_pos.Y > SlotHeight * i && _pos.Y < SlotHeight * (i + 1)) _rowNum = i;
                else i++;
            }
            
            return new Vector2i (_colNum, _rowNum);
        }

        private int GridToList(Vector2i _pos)
        {
            return _pos.X + _pos.Y * NUM_COLUMNS;
        }

        private bool ExistsPos(int _pos)
        {
            return _pos >= 0 && _pos < m_Items.Count;
        }
    }
}

﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWindowSize
{
    internal struct AllInputButtons
    {
        private const Keys kA_ButtonKey = Keys.K;
        private const Keys kB_ButtonKey = Keys.L;
        private const Keys kX_ButtonKey = Keys.J;
        private const Keys kY_ButtonKey = Keys.I;

        private const Keys kBack_ButtonKey = Keys.F1;
        private const Keys kStart_ButtoKey = Keys.F2;

        private ButtonState GetState(ButtonState gamePadButtonState, Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key))
                return ButtonState.Pressed;

            if ((GamePad.GetState(PlayerIndex.One).IsConnected))
                return gamePadButtonState;

            return ButtonState.Released;
        }

        public ButtonState A
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.A, kA_ButtonKey); }
        }

        public ButtonState B
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.B, kB_ButtonKey); }
        }

        public ButtonState X
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.X, kX_ButtonKey); }
        }

        public ButtonState Y
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.Y, kY_ButtonKey); }
        }

        public ButtonState Back
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.Back, kBack_ButtonKey); }
        }

        public ButtonState Start
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.Start, kStart_ButtoKey); }
        }
    }

    internal struct AllInputTriggers
    {
        private const Keys kLeft_Trigger = Keys.N;
        private const Keys kRight_Trigger = Keys.M;
        const float kKeyTriggerValue = 3f;

        private float GetTriggerState(float gamePadTrigger, Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key))
                return kKeyTriggerValue;

            if (GamePad.GetState(PlayerIndex.One).IsConnected)
                return gamePadTrigger;

            return 0f;
        }

        public float Left
        {
            get { return GetTriggerState(GamePad.GetState(PlayerIndex.One).Triggers.Left, kLeft_Trigger); }
        }

        public float Right
        {
            get { return GetTriggerState(GamePad.GetState(PlayerIndex.One).Triggers.Right, kRight_Trigger); }
        }

    }

    internal struct AllThumbstick
    {
        const Keys kLeft_ThumbstickUp = Keys.W;
        const Keys kLeft_ThumbstickDown = Keys.S;
        const Keys kLeft_ThumbstickRight = Keys.D;
        const Keys kLeft_ThumbstickLeft = Keys.A;

        const Keys kRight_ThumbstickUp = Keys.Up;
        const Keys kRight_ThumbstickDown = Keys.Down;
        const Keys kRight_ThumbstickRIght = Keys.Right;
        const Keys kRight_ThumbstickLeft = Keys.Left;

        const float kKeyDownValue = 3f;

        private Vector2 ThumbStickState(Vector2 thumbStickValue, Keys up, Keys down, Keys left, Keys right)
        {
            Vector2 r = new Vector2(0f, 0f);

            if ((GamePad.GetState(PlayerIndex.One).IsConnected))
            {
                r = thumbStickValue;
            }

            if (Keyboard.GetState().IsKeyDown(up))
                r.Y -= kKeyDownValue;

            if (Keyboard.GetState().IsKeyDown(down))
                r.Y += kKeyDownValue;

            if (Keyboard.GetState().IsKeyDown(left))
                r.X -= kKeyDownValue;

            if (Keyboard.GetState().IsKeyDown(right))
                r.X += kKeyDownValue;


            return r;
        }

        public Vector2 Left
        {
            get { return ThumbStickState(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left, kLeft_ThumbstickUp, kLeft_ThumbstickDown, kLeft_ThumbstickLeft, kLeft_ThumbstickRight); }
        }

        public Vector2 Right
        {
            get { return ThumbStickState(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right, kRight_ThumbstickUp, kRight_ThumbstickDown, kRight_ThumbstickLeft, kRight_ThumbstickRIght); }
        }
    }

    
        static class InputWrapper
        {
            static public AllInputButtons Buttons = new AllInputButtons();
            static public AllInputTriggers Trigger = new AllInputTriggers();
            static public AllThumbstick Thumbstick = new AllThumbstick();

        }
    }


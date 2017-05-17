using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossZero.Lesson1
{
    class LogicGame
    {
        public StateGame state; 
        public FieldGame[] fields { get; private set; }

        public LogicGame()
        {
            state = StateGame.NotStart;
            fields = new FieldGame[9];
        }

        public void Start()
        {
            
            for (int i=0; i<fields.Length; i++)
            {
                fields[i]= FieldGame.EmptyField;
            }
            state = StateGame.InProgress;
        }

        public void End()
        {

            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = FieldGame.EmptyField;
            }
            state = StateGame.NotStart;
        }


        public void CompPlay()
        {
                for (int i=0; i<fields.Length; i++)
                {
                    if (fields[i] == FieldGame.EmptyField)
                    {
                        fields[i] = FieldGame.CompField;
                        return;
                    }
                }
        }


        public StateGame Step(int index, FieldGame PlayerField)
        {
 
            if (state != StateGame.InProgress)
            {
                return state;
                
            }
            if (index > -1 && index < fields.Length)
            {
                if(fields[index] !=FieldGame.EmptyField)
                {
                    throw new ExceptionButtonClickClass();
                }
                fields[index] = PlayerField;
                if (!CheckWin() && !CheckNotEmptyButtons())
                {
                    state = StateGame.NoWin;
                }
            }
            return state;
        }

        private bool CheckWin()
        {
            if (fields[0] == fields[1] && fields[1] == fields[2] && fields[0] != FieldGame.EmptyField)
            {
                state = (fields[0] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (fields[3] == fields[4] && fields[4] == fields[5] && fields[3] != FieldGame.EmptyField)
            {
                state = (fields[3] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (fields[6] == fields[7] && fields[7] == fields[8] && fields[6] != FieldGame.EmptyField)
            {
                state = (fields[6] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (fields[0] == fields[3] && fields[3] == fields[6] && fields[0] != FieldGame.EmptyField)
            {
                state = (fields[0] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (fields[1] == fields[4] && fields[4] == fields[7] && fields[1] != FieldGame.EmptyField)
            {
                state = (fields[1] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (fields[2] == fields[5] && fields[5] == fields[8] && fields[2] != FieldGame.EmptyField)
            {
                state = (fields[2] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (fields[0] == fields[4] && fields[4] == fields[8] && fields[4] != FieldGame.EmptyField)
            {
                state = (fields[4] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (fields[2] == fields[4] && fields[4] == fields[6] && fields[4] != FieldGame.EmptyField)
            {
                state = (fields[4] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            return false;
        }

        private bool CheckNotEmptyButtons()
        {
            for (int i = 0; i < fields.Length; ++i)
            {
                if (fields[i] == FieldGame.EmptyField)
                {
                    return true;
                }
            }
            return false;
        }
    }

}

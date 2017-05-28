using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossZero.Lesson1
{
    public class LogicGame
    {
        public StateGame State { get; private set; } 
        public FieldGame[] Fields { get; private set; }

        public LogicGame()
        {
            State = StateGame.NotStart;
            Fields = new FieldGame[9];
        }

        public void Start()
        {
            
            for (int i=0; i<Fields.Length; i++)
            {
                Fields[i]= FieldGame.EmptyField;
            }
            State = StateGame.InProgress;

        }

        public void End(string Marker)
        {
            SaveStat(Marker);
            for (int i = 0; i < Fields.Length; i++)
            {
                Fields[i] = FieldGame.EmptyField;
            }
            State = StateGame.NotStart;

        }


        public void CompPlay()
        {
                for (int i=0; i<Fields.Length; i++)
                {
                    if (Fields[i] == FieldGame.EmptyField)
                    {
                        Fields[i] = FieldGame.CompField;
                        return;
                    }
                }
        }


        public StateGame Step(int index, FieldGame PlayerField)
        {
 
            if (State != StateGame.InProgress)
            {
                return State;
                
            }
            if (index > -1 && index < Fields.Length)
            {
                if(Fields[index] !=FieldGame.EmptyField)
                {
                    throw new ExceptionButtonClickClass();
                }
                Fields[index] = PlayerField;
                if (!CheckWin() && !CheckNotEmptyButtons())
                {
                    State = StateGame.NoWin;
                }
            }
            return State;
        }

        private bool CheckWin()
        {
            if (Fields[0] == Fields[1] && Fields[1] == Fields[2] && Fields[0] != FieldGame.EmptyField)
            {
                State = (Fields[0] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (Fields[3] == Fields[4] && Fields[4] == Fields[5] && Fields[3] != FieldGame.EmptyField)
            {
                State = (Fields[3] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (Fields[6] == Fields[7] && Fields[7] == Fields[8] && Fields[6] != FieldGame.EmptyField)
            {
                State = (Fields[6] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (Fields[0] == Fields[3] && Fields[3] == Fields[6] && Fields[0] != FieldGame.EmptyField)
            {
                State = (Fields[0] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (Fields[1] == Fields[4] && Fields[4] == Fields[7] && Fields[1] != FieldGame.EmptyField)
            {
                State = (Fields[1] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (Fields[2] == Fields[5] && Fields[5] == Fields[8] && Fields[2] != FieldGame.EmptyField)
            {
                State = (Fields[2] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (Fields[0] == Fields[4] && Fields[4] == Fields[8] && Fields[4] != FieldGame.EmptyField)
            {
                State = (Fields[4] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            if (Fields[2] == Fields[4] && Fields[4] == Fields[6] && Fields[4] != FieldGame.EmptyField)
            {
                State = (Fields[4] == FieldGame.CompField) ? StateGame.CompWin : StateGame.UserWin;
                return true;
            }
            return false;
        }

        private bool CheckNotEmptyButtons()
        {
            for (int i = 0; i < Fields.Length; ++i)
            {
                if (Fields[i] == FieldGame.EmptyField)
                {
                    return true;
                }
            }
            return false;
        }

         List<Statistic> data;

        private void SaveStat(string Marker)
        {
            try
            {
                string filePath = @"c:\stat\stats.json";
                //Serializer.SetData(filePath, data);
                data = Serializer.GetData(filePath);
                data.Add(new Statistic()
                {
                    Data = DateTime.Now,
                    CountUserStep = MainWindow.Counter+1,
                    Marker = Marker,
                    Result = State == StateGame.CompWin ? "Компьютер" : State == StateGame.UserWin ? "Пользователь" : "Ничья"
                });
                Serializer.SetData(filePath, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}

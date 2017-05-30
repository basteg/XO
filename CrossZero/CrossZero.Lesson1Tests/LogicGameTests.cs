using NUnit.Framework;
using CrossZero.Lesson1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;

namespace CrossZero.Lesson1.Tests
{
    [TestFixture()]
    public class LogicGameTests
    {
        [Test()]
        public void LogicGameTest()
        {
            var logic = new LogicGame();
            Assert.That(logic.State, Is.EqualTo(StateGame.NotStart), "Game state is not NotStart");
            Assert.That(logic.Fields.Length, Is.EqualTo(9), "Incorrect fields count");
        }

        [Test()]
        public void StartTest()
        {
            var logic = new LogicGame();

            logic.Start();
            Assert.That(logic.State, Is.EqualTo(StateGame.InProgress), 
                        "Game state is not in progress.");

            Assert.That(logic.Fields.Where(c => c != FieldGame.EmptyField).Count(), Is.EqualTo(0),
                        "All filds must be empty at game start.");
        }

        [Test()]
        public void EndTest()
        {
            var marker = new Fixture().Create<string>();
            var logic = new LogicGame();
            logic.End(marker);
            Assert.That(logic.Fields.Where(c => c != FieldGame.EmptyField).Count(), Is.EqualTo(0),
                        "All filds must be empty at game start.");
            Assert.That(logic.State, Is.EqualTo(StateGame.NotStart), "Game state is not NotStart");

        }

        [Test()]
        public void CompPlayTest()
        {
            var logic = new LogicGame();
            logic.CompPlay();
            Assert.That(logic.Fields.Where(c => c == FieldGame.CompField).Count(), Is.EqualTo(1), "Компьютер занимает более одного поля за ход");
        }

        [Test()]
        public void StepTest()
        {
            var logic = new LogicGame();
            var index = 5;
            var playerField = FieldGame.UserField;
            Assert.That((logic.Step(index, playerField)), Is.EqualTo(StateGame.NotStart), "Не возвращается статус игры NotStart");
        }

        [Test()]
        public void StepTestExeption()
        {
            var logic = new LogicGame();
            var index = 5;
            logic.State = StateGame.InProgress;
            logic.Fields[5] = FieldGame.UserField;
            var playerField = FieldGame.UserField;
            Assert.That(() => logic.Step(index, playerField), 
                        Throws.TypeOf(typeof(ExceptionButtonClickClass)), "Не работает исключение выбора занятого поля");
            
            
        }
    }
}
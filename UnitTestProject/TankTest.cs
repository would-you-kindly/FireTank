using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FireSafety;

namespace UnitTestProject
{
    [TestClass]
    public class TankTest
    {
        ResourceHolder resources;

        [TestInitialize]
        public void Init()
        {
            resources = new ResourceHolder();

            // Загружаем текстуры
            resources.LoadTexture(FireSafety.Textures.ID.House, "Media/Textures/House.png");
            resources.LoadTexture(FireSafety.Textures.ID.BurnedHouse, "Media/Textures/BurnedHouse.png");
            resources.LoadTexture(FireSafety.Textures.ID.Fire, "Media/Textures/Fire.png");
            resources.LoadTexture(FireSafety.Textures.ID.RedTank, "Media/Textures/RedTank.png");
            resources.LoadTexture(FireSafety.Textures.ID.RedTurret, "Media/Textures/RedTurret.png");
            resources.LoadTexture(FireSafety.Textures.ID.BlueTank, "Media/Textures/BlueTank.png");
            resources.LoadTexture(FireSafety.Textures.ID.BlueTurret, "Media/Textures/BlueTurret.png");
            resources.LoadTexture(FireSafety.Textures.ID.YellowTank, "Media/Textures/YellowTank.png");
            resources.LoadTexture(FireSafety.Textures.ID.YellowTurret, "Media/Textures/YellowTurret.png");
            resources.LoadTexture(FireSafety.Textures.ID.GreenTank, "Media/Textures/GreenTank.png");
            resources.LoadTexture(FireSafety.Textures.ID.GreenTurret, "Media/Textures/GreenTurret.png");
            resources.LoadTexture(FireSafety.Textures.ID.PinkTank, "Media/Textures/PinkTank.png");
            resources.LoadTexture(FireSafety.Textures.ID.PinkTurret, "Media/Textures/PinkTurret.png");
            resources.LoadTexture(FireSafety.Textures.ID.GreyTank, "Media/Textures/GreyTank.png");
            resources.LoadTexture(FireSafety.Textures.ID.GreyTurret, "Media/Textures/GreyTurret.png");
            resources.LoadTexture(FireSafety.Textures.ID.Tree, "Media/Textures/Tree.png");
            resources.LoadTexture(FireSafety.Textures.ID.BurnedTree, "Media/Textures/BurnedTree.png");
            resources.LoadTexture(FireSafety.Textures.ID.Lake, "Media/Textures/Lake.png");
            resources.LoadTexture(FireSafety.Textures.ID.Rock, "Media/Textures/Rock.png");

            // Загружаем шрифты
            resources.LoadFont(FireSafety.Fonts.ID.Sansation, "Media/Sansation.ttf");
        }

        [TestMethod]
        public void TankMoveCommand_Forward_TankOn0XAndMinus32Y()
        {
            // Arrange
            Tank tank = new Tank(FireSafety.Textures.ID.RedTank, 
                FireSafety.Textures.ID.RedTurret, resources, Tank.TankColor.Red);
            tank.SetPosition(new Vector2f(0, 0));
            tank.SetRotation(0);

            // Act
            tank.MovementCommand(MoveCommand.Commands.Forward);

            // Assert
            Assert.AreEqual(new Vector2f(0, -32), tank.sprite.Position);
        }

        [TestMethod]
        public void asd()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {  //arrange
            string[] barriosPrueba = { "a", "b", "c", "d", "e" };
            Pedido[] pedidosPrueba = {
            new Pedido(){Barrio = "a", CantidadGalletas = 20},
            new Pedido(){Barrio = "b", CantidadGalletas = 25},
            new Pedido(){Barrio = "c", CantidadGalletas = 30},
            new Pedido(){Barrio = "d", CantidadGalletas = 20},
            new Pedido(){Barrio = "e", CantidadGalletas = 13},
            new Pedido(){Barrio = "c", CantidadGalletas = 35},
            new Pedido(){Barrio = "d", CantidadGalletas = 14},
            new Pedido(){Barrio = "e", CantidadGalletas = 22}
            };

            //act
            int[] resultadosPrueba = Program.TotalizaPedidosBarrio(pedidosPrueba, barriosPrueba);

            //assert
            int pedidosEsperados = 2;
            int pedidosObtenidos = resultadosPrueba[4];
            Assert.AreEqual(pedidosEsperados, pedidosObtenidos);
        }

        //*******************************************************************************************
        //Se pretende obtener un resultado total de pedidos en el barrio 'e' distinto a lo esperado
        [TestMethod]
        public void ValidarPedidosTotalesErroneo()
        {
            //arrange
            string[] barriosPrueba = { "a", "b", "c", "d", "e" };
            Pedido[] pedidosPrueba = {
            new Pedido(){Barrio = "a", CantidadGalletas = 12},
            new Pedido(){Barrio = "b", CantidadGalletas = 25},
            new Pedido(){Barrio = "c", CantidadGalletas = 15},
            new Pedido(){Barrio = "d", CantidadGalletas = 20},
            new Pedido(){Barrio = "e", CantidadGalletas = 13},
            new Pedido(){Barrio = "a", CantidadGalletas = 42},
            new Pedido(){Barrio = "c", CantidadGalletas = 14},
            new Pedido(){Barrio = "d", CantidadGalletas = 32}
            };

            //act
            int[] resultadosPrueba = Program.TotalizaPedidosBarrio(pedidosPrueba, barriosPrueba);


            //assert
            int pedidosEsperados = 3;
            int pedidosObtenidos = resultadosPrueba[0];
            Assert.AreNotEqual(pedidosEsperados, pedidosObtenidos);
        }

        //*******************************************************************************************
        //Se espera obtener el total de barrios que tienen m�s de un pedido realizado, es decir, los pedidos que tienen repetici�n de barrio
        [TestMethod]
        public void ValidarCantidadDePedidosConRepetido()
        {
            //arrange
            string[] barriosPrueba = { "a", "b", "c", "d", "e" };
            Pedido[] pedidosPrueba = {
            new Pedido(){Barrio = "a", CantidadGalletas = 20},
            new Pedido(){Barrio = "c", CantidadGalletas = 25},
            new Pedido(){Barrio = "e", CantidadGalletas = 30},
            new Pedido(){Barrio = "d", CantidadGalletas = 20},
            new Pedido(){Barrio = "e", CantidadGalletas = 13},
            new Pedido(){Barrio = "b", CantidadGalletas = 35},
            new Pedido(){Barrio = "d", CantidadGalletas = 14},
            new Pedido(){Barrio = "a", CantidadGalletas = 22}
            };

            //act
            int[] resultadosPrueba = Program.TotalizaPedidosBarrio(pedidosPrueba, barriosPrueba);


            //assert
            int pedidosConRepetidosEsperados = 3; //Se espera leer 'a','d' y 'e' por tener m�s de un pedido en el barrio
            int barriosConPedidoRepetido = 0;
            for (int i = 0; i < resultadosPrueba.Length; i++)
                if (resultadosPrueba[i] > 1)
                    barriosConPedidoRepetido++;
            int pedidosObtenidos = barriosConPedidoRepetido;
            Assert.AreEqual(pedidosConRepetidosEsperados, pedidosObtenidos);
        }

        //*********************************************************************************************
        //**********************************************************************************************
        //*********************************************************************************************

        //Se espera tener una predicci�n igual al total de galletas entre pedidos en el barrio 'e'
        [TestMethod]
        public void ValidarTotalGalletasCorrecto()
        {
            //arrange
            string[] barriosPrueba = { "a", "b", "c", "d", "e" };
            Pedido[] pedidosPrueba = {
            new Pedido(){Barrio = "a", CantidadGalletas = 20},
            new Pedido(){Barrio = "b", CantidadGalletas = 25},
            new Pedido(){Barrio = "c", CantidadGalletas = 30},
            new Pedido(){Barrio = "d", CantidadGalletas = 20},
            new Pedido(){Barrio = "e", CantidadGalletas = 13},
            new Pedido(){Barrio = "c", CantidadGalletas = 35},
            new Pedido(){Barrio = "d", CantidadGalletas = 14},
            new Pedido(){Barrio = "e", CantidadGalletas = 22}
            };

            //act
            int[] resultadosPrueba = Program.TotalizaGalletasBarrio(pedidosPrueba, barriosPrueba);


            //assert
            int galletasEsperadas = 35;
            int galletasTotales = resultadosPrueba[4];
            Assert.AreEqual(galletasEsperadas, galletasTotales);
        }

        //*********************************************************************************
        //Se pretende obtener un resultado de galletas totales en el barrio 'e' distinto a las que realmente se esperaban
        [TestMethod]
        public void ValidarTotalGalletasErroneo()
        {
            //arrange
            string[] barriosPrueba = { "a", "b", "c", "d", "e" };
            Pedido[] pedidosPrueba = {
            new Pedido(){Barrio = "a", CantidadGalletas = 20},
            new Pedido(){Barrio = "b", CantidadGalletas = 25},
            new Pedido(){Barrio = "c", CantidadGalletas = 30},
            new Pedido(){Barrio = "d", CantidadGalletas = 20},
            new Pedido(){Barrio = "e", CantidadGalletas = 13},
            new Pedido(){Barrio = "c", CantidadGalletas = 35},
            new Pedido(){Barrio = "d", CantidadGalletas = 14},
            new Pedido(){Barrio = "e", CantidadGalletas = 22}
            };

            //act
            int[] resultadosPrueba = Program.TotalizaGalletasBarrio(pedidosPrueba, barriosPrueba);


            //assert
            int galletasEsperadas = 42;
            int galletasTotales = resultadosPrueba[4];
            Assert.AreNotEqual(galletasEsperadas, galletasTotales);
        }

        //*********************************************************************************
        //Se quiere obtener el total de galletas en todos los pedidos y que sea igual a lo que esperamos del total
        [TestMethod]
        public void ValidarGalletasTotalesDePedidos()
        {
            //arrange
            string[] barriosPrueba = { "a", "b", "c", "d", "e" };
            Pedido[] pedidosPrueba = {
            new Pedido(){Barrio = "a", CantidadGalletas = 20},
            new Pedido(){Barrio = "b", CantidadGalletas = 20},
            new Pedido(){Barrio = "c", CantidadGalletas = 30},
            new Pedido(){Barrio = "d", CantidadGalletas = 20},
            new Pedido(){Barrio = "e", CantidadGalletas = 10},
            new Pedido(){Barrio = "c", CantidadGalletas = 35},
            new Pedido(){Barrio = "d", CantidadGalletas = 15},
            new Pedido(){Barrio = "e", CantidadGalletas = 10}
            };

            //act
            int[] resultadosPrueba = Program.TotalizaGalletasBarrio(pedidosPrueba, barriosPrueba);

            //assert
            int galletasTotalesEsperadas = 160;
            int resultados = 0;
            for (int i = 0; i < resultadosPrueba.Length; i++)
                resultados += resultadosPrueba[i];
            int galletasTotalesReales = resultados;
            Assert.AreEqual(galletasTotalesEsperadas, galletasTotalesReales);
        
    }
    }
}
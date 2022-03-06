using ExpectedObjects;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void CriarCurso()
        {
            //Arrange
            const string nome = "TI";
            const double cargaHoraria = 80;
            const PublicoAlvoEnum publicoAlvo = PublicoAlvoEnum.Estudante;
            const decimal valor = 950;

            //Act
            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            //Assert
            Assert.Equal(nome, curso.Nome);
            Assert.Equal(cargaHoraria, curso.CargaHoraria);
            Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(valor, curso.Valor);
        }

        [Fact]
        public void CriarCursoComExpected()
        {
            //Arrange
            var cursoEsperado = new
            {
                Nome = "TI",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvoEnum.Universitario,
                Valor = (decimal)950
            };

            //Act
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            //Assert
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void VerificarSeONomeEInvalido(string nomeInvalidado)
        {
            var cursoEsperado = new
            {
                Nome = nomeInvalidado,
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvoEnum.Universitario,
                Valor = (decimal)950
            };

            var message = Assert.Throws<ArgumentException>(()=>
            new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).Message;
            Assert.Equal("Nome Inválido", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void VerificarSeACargaHorariaEMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "TI",
                CargaHoraria = cargaHorariaInvalida,
                PublicoAlvo = PublicoAlvoEnum.Universitario,
                Valor = (decimal)950
            };

            var message = Assert.Throws<ArgumentException>(() =>
            new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).Message;
            Assert.Equal("Carga horária Inválido", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void VerificarSeOValorEMenorQue1(decimal valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "TI",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvoEnum.Universitario,
                Valor = valorInvalido
            };

            var message = Assert.Throws<ArgumentException>(() =>
            new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).Message;
            Assert.Equal("valor Inválido", message);
        }
    }
}

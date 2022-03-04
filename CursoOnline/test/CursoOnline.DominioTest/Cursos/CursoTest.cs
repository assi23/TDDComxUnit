using ExpectedObjects;
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
    }
}

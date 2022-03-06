using System;
using System.Collections.Generic;

namespace CursoOnline.DominioTest.Cursos
{
    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvoEnum publicoAlvo, decimal valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Inválido");

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Inválido");

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Inválido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvoEnum PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }

    public enum PublicoAlvoEnum
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstructurasLineales;

namespace Materias
{
    public class Asignatura : IComparable
    {
        public int? codigo, creditos;
        public int semestre = 0;
        public bool cursado = false;
        public bool obligatoria;
        public string nombreAsignatura;
        public int? codigoSede;
        public MyLinkedList<int>? programasAsociados;
        public string? componente;
        public MyLinkedList<string>? NombrePrerrequisito;
        public MyLinkedList<int>? prerrequisito;
        public MyLinkedList<int>? correquisito;
        public Asignatura(int codigo,
                          string nombre,
                          int creditos,
                          bool obligatoria,
                          MyLinkedList<int> prerrequisito,
                          MyLinkedList<int> correquisito,
                          string componente,
                          MyLinkedList<int> programasAsociados
                          )
        {
            this.codigo = codigo;
            this.nombreAsignatura = nombre;
            this.creditos = creditos;
            this.programasAsociados = programasAsociados;
            this.componente = componente;
            this.correquisito = correquisito;
            this.prerrequisito = prerrequisito;
            this.obligatoria = obligatoria;
        }
        public Asignatura()
        {
            codigo = null; nombreAsignatura = null;
            codigoSede = null; programasAsociados = null;
            correquisito = null; componente = null; prerrequisito = null;
        }
        public Asignatura(int codigo,
                          string nombreAsignatura,
                          int creditos,
                          int codigoSede,
                          MyLinkedList<int> programasAsociados,
                          string componente,
                          MyLinkedList<string>? NombrePrerrequisito,
                          MyLinkedList<int> prerrequisito,
                          MyLinkedList<int> correquisito)
        {
            if (string.IsNullOrEmpty(nombreAsignatura))
            {
                throw new ArgumentException($"'{nameof(nombreAsignatura)}' cannot be null or empty.", nameof(nombreAsignatura));
            }

            if (string.IsNullOrEmpty(componente))
            {
                throw new ArgumentException($"'{nameof(componente)}' cannot be null or empty.", nameof(componente));
            }
            this.codigo = codigo;
            this.nombreAsignatura = nombreAsignatura;
            this.creditos = creditos;
            this.codigoSede = codigoSede;
            this.programasAsociados = programasAsociados;
            this.componente = componente;
            this.correquisito = correquisito;
            this.prerrequisito = prerrequisito;
            this.NombrePrerrequisito = NombrePrerrequisito;
        }
        public void MostrarPrerrequisitos()
        {
            if (prerrequisito?.IsEmpty() == false)
            {
                for (int i = 0; i < prerrequisito.GetLength(); i++)
                {
                    Console.WriteLine("Pre-requisitos: ");
                    Console.Write(prerrequisito.GetValue(i) + "  ");
                }
                Console.WriteLine();
            }

        }
        public void MostrarInfo()
        {
            Console.Write("Codigo: " + codigo +" ");
            Console.Write("Nombre: " + nombreAsignatura + " ");
            Console.Write("Creditos: " + creditos + " ");
            Console.WriteLine("Componente: " + componente);

        }
        public void SetSemestre(int semestre) { this.semestre = semestre; }
        public int GetSemestre() { return this.semestre; }
        public void MostrarProgramaAsociado()
        {
            if (programasAsociados?.IsEmpty() == false)
            {
                int n = programasAsociados.GetLength() % 4;
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Si quiere cursar " +nombreAsignatura+ "le recomendamos estudiar el programa: " + programasAsociados.GetValue(i) + "  ");
                }
                Console.WriteLine();
            }
             
        }

        public void AñadirPrerrequisito(int dato)
        {
            prerrequisito?.AddToEnd(dato);
        }
        public bool TienePrerrequisito() { return prerrequisito.IsEmpty(); }
        public string mostrarNombre(int codigo2)
        {
            if (codigo == codigo2) { return nombreAsignatura; }
            else { return ""; }
        }

        //public int CompareTo(Asignatura? other)
        //{
        //    int resultado;
        //    if (other.codigo > this.codigo) { resultado = 1; }
        //    else if(other.codigo < this.codigo) { resultado = -1; }
        //    else   resultado = 0;
        //    return resultado;
        //}

        

        public int CompareTo(object? obj)
        {
            Asignatura temp=(Asignatura?)obj;
            return this.nombreAsignatura.CompareTo(temp.nombreAsignatura);

        }
        public override String ToString()
        {
            return String.Format("[{0},{1},{2}]", nombreAsignatura, codigo, creditos);
        }
    }
    }

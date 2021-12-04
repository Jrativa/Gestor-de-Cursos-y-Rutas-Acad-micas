﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using EstructurasLineales;
using Materias;
using Newtonsoft.Json;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Main
{
    class MateriasMain
    {
        public static MyLinkedList<Asignatura> Asignaturas = DeserializeJson(LeerJson(@"../../../Materias/asignaturas.json"));
        public static void VolverMenu()
        {
            Console.WriteLine("Presione 1 para volver al menu de opciones, 2 para salir del programa");
            string s2 = Console.ReadLine();
            switch (s2)
            {
                case "1":
                    Menu(); break;
                case "2":
                    break;
                default:VolverMenu();break;
            }
        }
        public static void Menu()
        {
            Console.WriteLine("1. Organizar Asignaturas");
            Console.WriteLine("2. Selecciona asignaturas para generar rutas");
            Console.WriteLine("3. Buscar asignatura");
            Console.WriteLine("4. Cargar un archivo txt para ver mis asignaturas");
            Console.WriteLine("5. Consultar asignaturas disponibles");
            Console.WriteLine("Que deseas hacer : ");
            string s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    PedirAsignaturas();
                    VolverMenu();
                    break;
                case "2":
                    Console.WriteLine("Introduzca el nombre de la asignatura que quiere cursar: ");
                    string AsignaturaABuscar2 = (char)(34) + Console.ReadLine() + (char)(34);
                    Asignatura MateriaEncontrada2 = BuscarAsignatura(AsignaturaABuscar2, Asignaturas);
                    SugerirRutas(MateriaEncontrada2);
                    VolverMenu();
                    break;
                case "3":
                    Console.WriteLine("Introduzca el nombre de la asignatura que quiere buscar: ");
                    string AsignaturaABuscar = (char)(34) + Console.ReadLine() + (char)(34);
                    Asignatura MateriaEncontrada = BuscarAsignatura(AsignaturaABuscar, Asignaturas);
                    if (MateriaEncontrada != null)
                    {
                        MateriaEncontrada.MostrarInfo();

                    }
                    else Console.WriteLine("La asignatura no se ha encontrado");
                    VolverMenu();
                    break;
                case "4":
                    Console.WriteLine("Introduzca la ruta del directorio donde está su archivo: ");
                    string rutaArchivo = Console.ReadLine();
                    Console.WriteLine("Nombre de su archivo: ");
                    string nombreArchivo = Console.ReadLine();
                    LeerArchivo(rutaArchivo + (char)(92) + nombreArchivo + ".txt");
                    VolverMenu();
                    break;
                case "5":
                    string disponibles = LeerJson(@"../../../Materias/asignaturas.json");
                    Console.WriteLine(disponibles); VolverMenu(); break;
                default: Console.WriteLine("Opcion invalida, intente  nuevamente"); Menu(); break;
            }
        }
        public static void mostrarRenglones(MyStack<string> pila)
        {
            while (!pila.IsEmpty())
            {
                Console.WriteLine(pila.Pop());
            }
        }
        public static void LeerArchivo(string rutaArchivo)
        {
            string linea;
            MyLinkedList<string> renglones = new MyLinkedList<string>();
            try
            {
                StreamReader lector = new StreamReader(rutaArchivo);
                linea = lector.ReadLine();
                Console.WriteLine(Int32.Parse(linea.Split(" ")[1]) + 3);
                MyStack<string> renglonesApilados1 = new MyStack<string>();
                MyStack<string> renglonesApilados2 = new MyStack<string>();
                MyStack<string> renglonesApilados3 = new MyStack<string>();
                MyStack<string> renglonesApilados4 = new MyStack<string>();
                MyStack<string> renglonesApilados5 = new MyStack<string>();
                MyStack<string> renglonesApilados6 = new MyStack<string>();
                MyStack<string> renglonesApilados7 = new MyStack<string>();
                MyStack<string> renglonesApilados8 = new MyStack<string>();
                MyStack<string> renglonesApilados9 = new MyStack<string>();
                MyStack<string> renglonesApilados10 = new MyStack<string>();
                while (linea != null)
                {
                    renglones.AddToEnd(linea);
                    switch ((linea.Split(" ")[1]))
                    {
                        case "1": renglonesApilados1.Push(linea); break;
                        case "2": renglonesApilados2.Push(linea); break;
                        case "3": renglonesApilados3.Push(linea); break;
                        case "4": renglonesApilados4.Push(linea); break;
                        case "5": renglonesApilados5.Push(linea); break;
                        case "6": renglonesApilados6.Push(linea); break;
                        case "7": renglonesApilados7.Push(linea); break;
                        case "8": renglonesApilados8.Push(linea); break;
                        case "9": renglonesApilados9.Push(linea); break;
                        case "10": renglonesApilados10.Push(linea); break;

                    }
                    linea = lector.ReadLine();
                }
                lector.Close();
                mostrarRenglones(renglonesApilados1);
                mostrarRenglones(renglonesApilados2);
                mostrarRenglones(renglonesApilados3);
                mostrarRenglones(renglonesApilados4);
                mostrarRenglones(renglonesApilados5);
                mostrarRenglones(renglonesApilados6);
                mostrarRenglones(renglonesApilados7);
                mostrarRenglones(renglonesApilados8);
                mostrarRenglones(renglonesApilados9);
                mostrarRenglones(renglonesApilados10);
            }
            catch (Exception)
            {
                Console.WriteLine("La ruta no es valida, intente de nuevo");
                Console.WriteLine("Introduzca la ruta del directorio donde está su archivo: ");
                string rutaArchivo2 = Console.ReadLine();
                Console.WriteLine("Nombre de su archivo: ");
                string nombreArchivo = Console.ReadLine();
                LeerArchivo(rutaArchivo2 + (char)(92) + nombreArchivo + ".txt");
            }
        }
        public static void PedirAsignaturas()
        {
            MyQueue<Asignatura> asignaturas = new MyQueue<Asignatura>();
            Console.WriteLine("¿Cuantas asignaturas quieres planificar ?");
            string numero = Console.ReadLine();
            int n = Int32.Parse(numero);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nombre de la asignatura:");
                string nombreAsignatura = Console.ReadLine().ToUpper();
                Console.WriteLine("Nombre de prerrequisitos(separados por comas):");
                string prerrequisito = Console.ReadLine().ToUpper().Trim();
                MyLinkedList<string> prerrequisitos = new MyLinkedList<string>();
                Asignatura aux = new Asignatura(); aux.nombreAsignatura = nombreAsignatura;
                foreach (string materia in prerrequisito.Split(","))
                {
                    prerrequisitos.AddToEnd(materia.Trim());
                }
                aux.NombrePrerrequisito = prerrequisitos;
                asignaturas.enqueue(aux);
            }
            Organizar(asignaturas);
        }
        public static int AsignarSemestre(Asignatura asignatura, MyLinkedList<Asignatura> Asignaturas, MyQueue<Asignatura> Asignaturas2)
        {
            if (asignatura.NombrePrerrequisito == null || asignatura.NombrePrerrequisito.GetValue(0) == "")
            {
                return 1;
            }
            else
            {
                int n = asignatura.NombrePrerrequisito.GetLength();
                int semestre = 0;
                for (int j = 0; j < n; j++)
                {
                    int semestreAux = 0;
                    Asignatura aux = BuscarAsignatura(asignatura.NombrePrerrequisito.GetValue(j), Asignaturas);
                    if (aux == null) break;
                    if (aux == null) { aux = BuscarAsignatura(asignatura.NombrePrerrequisito.GetValue(j), Asignaturas2); }
                    if (aux.GetSemestre() == 0) { semestreAux = AsignarSemestre(aux, Asignaturas, Asignaturas2); }
                    else { semestreAux = aux.GetSemestre(); }
                    if (semestre == 0 || semestre < semestreAux) { semestre = semestreAux; }
                }
                return semestre + 1;
            }
        }

        public static void Organizar(MyQueue<Asignatura> Asignaturas)
        {
            MyQueue<Asignatura> Asignaturas2 = new MyQueue<Asignatura>();
            Console.WriteLine("Introduzca la ruta del directorio donde quiere que se guarde su archivo: ");
            string rutaArchivo = Console.ReadLine();
            Console.WriteLine("Introduzca el nombre para su archivo:");
            string nombreArchivo = Console.ReadLine();
            try
            {
                using (StreamWriter outputFile = new StreamWriter(rutaArchivo + (char)(92) + nombreArchivo + ".txt"))
                {
                    Asignatura aux1 = new Asignatura();
                    for (int i = 0; i < Asignaturas.GetLength(); i++)
                    {
                        aux1 = Asignaturas.dequeue(); i--;
                        Asignaturas2.enqueue(aux1);
                        aux1.SetSemestre(AsignarSemestre(aux1, Asignaturas, Asignaturas2));
                        outputFile.WriteLine("Semestre " + aux1.GetSemestre() + " --- " + aux1.nombreAsignatura);
                    }
                }
                LeerArchivo(rutaArchivo + (char)(92) + nombreArchivo + ".txt");
            }
            catch { Console.WriteLine("La ruta ingresada no es valida"); }
        }
        
        public static Asignatura BuscarAsignatura(String Nombre, MyLinkedList<Asignatura> asignaturas)
        {
            int n = asignaturas.GetLength();
            Node<Asignatura> aux = asignaturas.GetHeadNode();
            for (int i = 0; i < n; i++)
            {
                string aux2 = aux.data.nombreAsignatura.ToLower().Trim();
                aux2=aux2.Replace('á', 'a'); aux2 = aux2.Replace('é', 'e'); aux2 = aux2.Replace('í', 'i'); aux2 = aux2.Replace('ó', 'o'); aux2 = aux2.Replace('ú', 'u');

                if (aux2 == Nombre.ToLower().Trim())
                {
                    return aux.data;
                }
                else { aux = aux.nextNode; }
            }
            return null;
        }
        public static string LeerJson(string ruta)
        {
            string asignaturasFromJson;
            using(var reader = new StreamReader(ruta))
            {
                asignaturasFromJson = reader.ReadToEnd();
            }
            return asignaturasFromJson;
        }
        public static MyLinkedList<Asignatura> DeserializeJson(string asignaturasFromJson)
        {
            MyLinkedList<Asignatura> prueba = new MyLinkedList<Asignatura>();
            for (int i = 1; i < asignaturasFromJson.Split("{").Length; i++)
            {
                int codigoAsignatura = Int32.Parse(asignaturasFromJson.Split("{")[i].Split(',')[0].Split(':')[1]);
                string nombreAsignatura = (asignaturasFromJson.Split("{")[i].Split(',')[1].Split(':')[1]);
                int creditos = Int32.Parse(asignaturasFromJson.Split("{")[i].Split(',')[2].Split(':')[1]);
                MyLinkedList<int> prerrequisito = new MyLinkedList<int>();
                string[] aux2 = asignaturasFromJson.Split("{")[i].Split(',');
                try
                {
                    string[] temp = (aux2[4].Split(':')[1].Split("\n"));
                    for (int j = 0; j < temp.Length; j++)
                    {
                        prerrequisito.AddToEnd(Int32.Parse(temp[j]));
                    }
                }
                catch { prerrequisito = null; }
                MyLinkedList<int> correquisito = new MyLinkedList<int>();
                try
                {
                    string[] temp = (asignaturasFromJson.Split("{")[i].Split(',')[5].Split(':')[1].Split('\n'));
                    for (int j = 0; j < temp.Length; j++)
                    {
                        correquisito.AddToEnd(Int32.Parse(temp[j]));
                    }
                }
                catch { correquisito = null; }
                string componente = asignaturasFromJson.Split("{")[i].Split(',')[6].Split(':')[1];
                MyLinkedList<int> programas = new MyLinkedList<int>();
                try
                {  
                    string[] temp = aux2[7].Split(':')[1].Split('}')[0].Replace('[', ' ').Replace(']', ' ').Trim().Split();
                    for (int j = 0; j < temp.Length; j++)
                    {                        
                        programas.AddToEnd(Int32.Parse(temp[j]));
                    }
                }
                catch { programas = null; }
                Asignatura aux = new Asignatura(codigoAsignatura,nombreAsignatura,creditos,false,prerrequisito,correquisito,componente,programas);
                prueba.AddToBeginning(aux);           
            }
            return prueba;
        }
        public static void SugerirRutas(Asignatura asignatura)
        {
            try
            {
                asignatura.MostrarProgramaAsociado();
            }
            catch (Exception e)
            {
                Console.WriteLine("No hay rutas", e.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al gestor de rutas academicas");
            Console.WriteLine("Opciones:");
            Menu();
            Console.WriteLine("Gracias por usar nuestros servicios");
        }
    }
}


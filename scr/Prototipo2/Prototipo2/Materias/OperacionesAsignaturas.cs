namespace Materias
{
    interface OperacionesAsignaturas{
	public void MostrarPrerrequisitos();
	public void MostrarProgramaAsociado();
	public void AñadirPrerrequisito(int dato);
	public bool TienePrerrequisito();
}

}
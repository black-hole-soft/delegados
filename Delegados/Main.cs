// Ejemplo útil para comprender la fundamentación
// e implementación de los operadores delegados en C#.
// En este caso, se implementa una delegación para
// lograr una comparación neutra en un algoritmo de
// clasificación.

// Luis Casillas 2005

using System;

namespace Delegados
{
	public delegate int Comparador(object obj1,object obj2);
	
	class Aux{
		private int a,b;
		private static int cuenta=0;
		private int serie;		
		public int A{
			get{return a;}
		}		
		public int B{
			get{return b;}
		}		
		public Aux(int a,int b){
			this.a=a;
			this.b=b;
			serie=cuenta++;
		}			
		public static int comparaDatos(object obj1,object obj2){
			Aux a1=(Aux)obj1;
			Aux a2=(Aux)obj2;
			int d1=a1.A+a1.B;
			int d2=a2.A+a2.B;
			if (d1>d2) return 1;
			if (d1<d2) return -1;
			return 0;
		}
		public override string ToString(){
			return "Objeto Aux"+serie+" [A: "+a+", B: "+b+"]";
		}
	}
	class Aux2{
		private double a,b,c;
		private static int cuenta=0;
		private int serie;		
		public double A{
			get{return a;}
		}		
		public double B{
			get{return b;}
		}	
		public double C{
			get{return c;}
		}	
		public Aux2(double a,double b,double c){
			this.a=a;
			this.b=b;
			this.c=c;
			serie=cuenta++;
		}			
		public static int comparaDatos(object obj1,object obj2){
			Aux2 a3=(Aux2)obj1;
			Aux2 a4=(Aux2)obj2;
			double d1=a3.A+a3.B;
			double d2=a4.A+a4.B;
			if (d1>d2) return 1;
			if (d1<d2) return -1;
			return 0;
		}
		public override string ToString(){
			return "Objeto Aux"+serie+" [A: "+a+", B: "+b+"C: "+c+"]";
		}
	}
	
	class MainClass
		{
		 Aux [] auxs=new Aux[20];
		 Aux2 [] auxs2=new Aux2[20];
		
		internal MainClass(){
			Random r=new Random();
			for(int i=0;i<auxs.Length;i++){
				auxs[i]=new Aux(r.Next(10),r.Next(10));
				auxs2[i]=new Aux2(r.Next(10),r.Next(10),r.Next(10));
			}
		}
		
		 internal void imprimeAuxs(string mensaje,object []cosas){
			Console.WriteLine("\n"+mensaje);
			for(int i=0;i<cosas.Length;i++){
				Console.WriteLine(cosas[i]);
			}
		}
		 internal void ordena(Comparador compara,object []cosas){
			Object temp;
			for (int i=0;i<cosas.Length;i++){
				for (int j=0;j<cosas.Length-1;j++){
					if (compara(cosas[j],cosas[j+1]) > 0 ){
						temp = cosas[j];
						cosas[j] = cosas[j+1];
						cosas[j+1] = (object)temp;
					}
				}
			}
		}
				
		public static void Main(string[] args){
			Comparador comp=new Comparador(Aux.comparaDatos);
			Comparador comp2=new Comparador(Aux2.comparaDatos);
			MainClass mc=new MainClass();
			mc.imprimeAuxs("Antes de Ordenar",mc.auxs);
			mc.ordena(comp,mc.auxs);
			mc.imprimeAuxs("Después de Ordenar",mc.auxs);
			mc.imprimeAuxs("Antes de Ordenar 2",mc.auxs2);
			mc.ordena(comp2,mc.auxs2);
			mc.imprimeAuxs("Después de Ordenar 2",mc.auxs2);
			Console.ReadLine();
		}
	}
}

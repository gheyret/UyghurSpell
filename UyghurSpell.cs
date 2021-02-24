/*
 * Created by SharpDevelop.
 * User: Gheyret Kenji
 * Date: 2021/01/22
 * Time: 9:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

/*
 * Created by SharpDevelop.
 * User: gheyret
 * Date: 2010/01/05
 * Time: 16:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace UyghurSpell
{
	/// <summary>
	/// Description of TstTree.
	/// </summary>
	public class UyghurSpell: IComparer<NamzatQelip>
	{
		private UNode m_RootNode=null;
		private  int  m_SozSani=0;
		private int   nodeCnt=0;
		

		HashSet<string>  tmpNam = new HashSet<string>();
		List<NamzatQelip>     _namzatlar = new List<NamzatQelip>();
		
		public  Int64 Add(String soz,  Int64 tekrar=1)
		{
			string szWord = soz.Replace(Uyghur.Sozghuch,"").Trim().ToLower();
			if(szWord.Trim().Length==0){
				return 0;
			}
			szWord+='\0';
			if(m_RootNode==null)
			{
				m_RootNode=new UNode();
				m_RootNode.mHerp=szWord[0];
				nodeCnt++;
			}

			UNode curNode=m_RootNode;
			int pos=0;
			char Herp=szWord[pos];
			while(true){
				if(curNode.mHerp==Herp)
				{
					if(Herp=='\0')
					{
						if(curNode.mFreq==0){
							m_SozSani++;
						}
						curNode.mFreq = (curNode.mFreq+tekrar)<short.MaxValue?(short)(curNode.mFreq+tekrar):short.MaxValue;
						break;
					}
					pos++;
					Herp=szWord[pos];
					if(curNode.mNext==null)
					{
						curNode.mNext=new UNode();
						curNode.mNext.mHerp=Herp;
						nodeCnt++;
					}
					curNode=curNode.mNext;
				}
				else{
					if(curNode.mAlter==null){
						curNode.mAlter=new UNode();
						curNode.mAlter.mHerp=Herp;
						nodeCnt++;
					}
					curNode=curNode.mAlter;
				}
			}
			return curNode.mFreq;
		}

		public  bool IsListed(String szWord)
		{
			if (m_RootNode == null) return false;
			bool ret=_IsWordListed(m_RootNode,szWord.Trim().Replace(Uyghur.Sozghuch,"").ToLower());
			return ret;
		}
		
		private bool _IsWordListed(UNode node,String szWord)
		{
			UNode curNode=node;
			szWord+='\0';
			int len=szWord.Length;
			int pos=0;
			char Herp;
			bool ret=false;
			Herp=szWord[pos];
			while(curNode!=null)
			{
				if(curNode.mHerp==Herp)
				{
					if(curNode.mHerp=='\0')
					{
						ret = true;
						break;
					}
					pos++;
					Herp=szWord[pos];
					curNode = curNode.mNext;
				}
				else
				{
					curNode=curNode.mAlter;
				}
			}
			return ret;
		}
		
		public  int WordCount{
			get{
				return m_SozSani;
			}
		}
		
		public  bool LoadDictionary(string corpus, Uyghur.YEZIQ yeziq)
		{
			if (!File.Exists(corpus)) return false;
			return LoadDictionary(File.OpenRead(corpus), yeziq);
		}
		
		public  bool LoadDictionary(Stream instr,Uyghur.YEZIQ yeziq)
		{
			using (StreamReader sr = new StreamReader(instr,System.Text.Encoding.UTF8))
			{
				String line;
				while ((line = sr.ReadLine()) != null)
				{
					string[] lineParts = line.Split(null);
					if (lineParts.Length >= 2)
					{
						string key = lineParts[0];
						if(yeziq==Uyghur.YEZIQ.ULY){
							key  = Uyghur.UEY2ULY(key).ToLower();
						}
						else if(yeziq==Uyghur.YEZIQ.USY){
							key  = Uyghur.UEY2USY(key).ToLower();
						}
						Int64 count;
						if (Int64.TryParse(lineParts[1], out count))
						{
							Add(key, count);
						}
					}
				}
			}
			return true;
		}


		public List<string> GetSuggestions(String pattern)
		{
			tmpNam.Clear();
			_namzatlar.Clear();
			List<string>     Namzatlar = new List<string>();
			_GetSuggestions(m_RootNode,pattern.ToLower()+'\0',0,"");
			Namzatlar.AddRange(tmpNam);
			return Namzatlar;
		}
		
		
		private void _GetSuggestions(String pattern)
		{
			_GetSuggestions(m_RootNode,pattern+'\0',0,"");
			//System.Diagnostics.Debug.WriteLine(qelip + " --> " + Namzatlar.Count);
			return;
		}

		private void _GetSuggestions(UNode curNode,String pattern,int pos,String namzat)
		{
			if (curNode==null) return;
			char Herp=pattern[pos];
			if(curNode.mHerp==Herp||Herp=='?'||Herp=='*')
			{
				if(curNode.mHerp==0x0 && Herp=='\0')
				{
					if(!tmpNam.Contains(namzat))
					{
						tmpNam.Add(namzat);
						NamzatQelip nm = new NamzatQelip();
						nm.soz = namzat;
						nm.tekrar = curNode.mFreq;
						_namzatlar.Add(nm);
					}
				}
				else if(Herp=='*'){
					_SearchAll(curNode,namzat);
				}
				else{
					_GetSuggestions(curNode.mNext, pattern, pos+1,namzat+curNode.mHerp);
					_GetSuggestions(curNode.mAlter, pattern, pos,namzat);
				}
			}
			else
			{
				_GetSuggestions(curNode.mAlter, pattern, pos,namzat);
			}
		}
		
		
		private void _SearchAll(UNode curNode,String pattern){
			if(curNode!=null){
				if(curNode.mHerp==0x0){
					if(!tmpNam.Contains(pattern))tmpNam.Add(pattern);
				}
				_SearchAll(curNode.mNext, pattern+curNode.mHerp);
				_SearchAll(curNode.mAlter, pattern);
			}
		}
		
		
		//Namzat Sozlerni tepip chiqidu
		public  List<string> Lookup(string Soz)
		{
			tmpNam.Clear();
			_namzatlar.Clear();
			List<string> Namzatlar = new List<string>();
			if (m_RootNode == null) return Namzatlar;
			char[] herpler;
			String yasSoz;
			Soz = Soz.Trim().Replace(Uyghur.Sozghuch,"").ToLower();
			int lenSoz=Soz.Length;
			int i;

			//Barliq sozuq tashuwshlarni xatalashqan dep perez qilsaq
			herpler = Soz.ToCharArray();
			for(i = 0;i<herpler.Length;i++){
				if(Uyghur.IsSozuq(herpler[i])){
					herpler[i]='?';
				}
			}
			yasSoz=new String(herpler);
			_GetSuggestions(yasSoz);

			//Yuqiridiki barliq sozuq tawushlar xata dep qarap, andin bir bir herpning arqisidin birdin soz chushup qalghan dep qarisaq
			//Herp Bir Herpning aldida birdin herp chushup qalghan dep perez qilsaq
			string tmp;
			for(i=lenSoz;i>=0;i--)
			{
				tmp = yasSoz.Insert(i,"?");
				_GetSuggestions(tmp);
				if(i<yasSoz.Length){
					tmp = yasSoz.Remove(i,1);
					_GetSuggestions(tmp);
					tmp = yasSoz.Remove(i,1).Insert(i,"?");
					_GetSuggestions(tmp);
				}
			}
			
			
			for(i=lenSoz-1;i>=0;i--)
			{
				yasSoz = Soz.Insert(i,"?"); // Bir herp chsuhup qalghan
				_GetSuggestions(yasSoz);

				herpler=Soz.ToCharArray();
				herpler[i]='?';    //Birdin herp hata
				yasSoz=new String(herpler);
				_GetSuggestions(yasSoz);

				yasSoz = yasSoz.Insert(i,"?");
				_GetSuggestions(yasSoz);
				
				
				if((i-1)>=0){
					herpler[i-1]='?';  //xoshana ikki herp xata
					yasSoz=new String(herpler);
					_GetSuggestions(yasSoz);
				}
				
				if((i-2)>=0){
					herpler=Soz.ToCharArray();
					herpler[i]='?';    //Birdin herp hata
					herpler[i-2]='?';  //birin herpni atalap xatamu qaraydu
					yasSoz=new String(herpler);
					_GetSuggestions(yasSoz);
				}

				if((i-3)>=0){
					herpler=Soz.ToCharArray();
					herpler[i]='?';    //Birdin herp hata
					herpler[i-3]='?';  //birin herpni atalap xatamu qaraydu
					yasSoz=new String(herpler);
					_GetSuggestions(yasSoz);
				}
			}
						
			foreach(NamzatQelip qlp in _namzatlar)
			{
				short dist= (short)GetDistance(Soz,qlp.soz);
				qlp.ariliq = dist;
			}

			//Namzat Sozlerni eslidiki sozge yeqin we tekrarliqini asas qilip tizidu.
			_namzatlar.Sort(this);
			
			foreach(NamzatQelip qlp in _namzatlar)
			{
				if(Namzatlar.Count>=10){　//Nazatlarning sanini 10 da cheklep qoydum
					break;
				}
				Namzatlar.Add(qlp.soz);
			}

			i=1;
			while(i<lenSoz && lenSoz-i>=3)
			{
				yasSoz=Soz.Substring(0,lenSoz-i);
				if(IsListed(yasSoz)){
					if(!Namzatlar.Contains(yasSoz)){
						Namzatlar.Add(yasSoz);
					}
					break;
				}
				i++;
			}
			return Namzatlar;
		}
		
		public int Compare(NamzatQelip a,NamzatQelip b){
			if(a.ariliq==b.ariliq)
			{
				return b.tekrar-a.tekrar;
			}
			return a.ariliq-b.ariliq;
		}
		
		
		int GetDistance(string s, string t)
		{
			var bounds = new { Height = s.Length + 1, Width = t.Length + 1 };
			
			int[,] matrix = new int[bounds.Height, bounds.Width];
			
			for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
			for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; };
			
			for (int height = 1; height < bounds.Height; height++)
			{
				for (int width = 1; width < bounds.Width; width++)
				{
					int cost = (s[height - 1] == t[width - 1]) ? 0 : 1;
					int insertion = matrix[height, width - 1] + 1;
					int deletion = matrix[height - 1, width] + 1;
					int substitution = matrix[height - 1, width - 1] + cost;
					
					int distance = Math.Min(insertion, Math.Min(deletion, substitution));
					
					if (height > 1 && width > 1 && s[height - 1] == t[width - 2] && s[height - 2] == t[width - 1])
					{
						distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
					}
					
					matrix[height, width] = distance;
				}
			}
			
			return matrix[bounds.Height - 1, bounds.Width - 1];
		}
	}
	
	public class NamzatQelip{
		public string soz=null;
		public short  tekrar=-1;
		public short  ariliq=-1;
	}
	
	public class UNode
	{
		public char   mHerp='\0';
		public short  mFreq=0;
		public UNode  mNext=null;
		public UNode  mAlter=null;
	}
	
}
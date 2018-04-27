using System.Windows;
using System.Windows.Media;
using Bradesco.Apps;
using Bradesco.Apps.Estados;
using Bradesco.Apps.Folhetos;
using Bradesco.Apps.Prime;

namespace Bradesco {
	internal static class Controls {
		private static Main _main;
		private static Principal _principal;
		private static FundosDeInvestimento _fundosInvestimento;
		private static INSS _inss;

        private static TarifasPFLista _tarifasPfLista;
		private static TarifasPJLista _tarifasPjLista;
		private static TarifasPF _tarifasPf;
		private static TarifasPJ _tarifasPj;

        private static TarifasPFLista_old _tarifasPfLista_old;
        private static TarifasPJLista_old _tarifasPjLista_old;
        private static TarifasPF_old _tarifasPf_old;
        private static TarifasPJ_old _tarifasPj_old;

        private static TarifasPFVigencias _tarifasPfVigencias;
        private static TarifasPJVigencias _tarifasPjVigencias;
        private static PrimePFVigencias _primePfVigencias;

        private static InformativoAoPublico _informativoAoPublico;
		private static CanaisDeAcesso _canaisAcesso;
		private static SCR _scr;
		private static Procon _procon;
		private static ReclamacoesOuSugestoes _reclamacoesSugestoes;
		private static PrimeMenu _primeMenu;
		private static FolhetosIndice _folhetosIndice;

		private static FolhetosPF _folhetosPF;
		private static FolhetosEmpresasNegocios _folhetosPJ;
		private static FolhetosExclusive _folhetosExclusive;

		private static PrimeInformativoAoPublico _primeInformativo;
		private static Folhetos _primeFolhetos;
		private static PrimeFundosDeInvestimento _primeFundosDeInvestimento;
		private static PrimeSCR _primeScr;

        private static PrimePF _primePf;
		private static PrimePfLista _primePFLista;
		private static PrimePJ _primePj;
		private static PrimePjLista _primePJLista;

        private static PrimePF_old _primePf_old;
        private static PrimePfLista_old _primePFLista_old;

        private static Apps.Folhetos.FolhetosNavegador _folhetosNavegadorPF;
		private static Apps.Folhetos.FolhetosNavegador _folhetosNavegadorExclusive;
		private static Apps.Folhetos.FolhetosNavegador _folhetosNavegadorPJ;

        private static AL _stateAl;
        private static AM _stateAm;
        private static CE _stateCe;
        private static ES _stateEs;
        private static GO _stateGo;
        private static MA _stateMa;
        private static Apps.Estados.MS _stateMS;
        private static MT _stateMt;
        private static PA _statePa;
        private static PE _statePe;
        private static PI _statePi;
        private static RN _stateRn;
        private static RR _stateRr;
        private static TO _stateTo;
        private static BA _stateBa;
		private static DF _stateDf;
		private static MG _stateMg;
		private static PR _statePr;
		private static RJ _stateRj;
		private static RS _stateRs;
		private static SC _stateSc;
		private static SP _stateSp;

		private static AjudaMenuPrincipal _ajudaMenuPrincipal;
		private static AjudaMenuInterno _ajudaMenuInterno;

		internal static Main Home {
			get
			{
				return _main ?? (_main = new Main
				{
					HorizontalAlignment = HorizontalAlignment.Left,
					Margin = new Thickness(0, 0, -10, -8),
					VerticalAlignment= VerticalAlignment.Top,
					FontFamily = new FontFamily("NewJuneBook")
				});
			}
		}
		internal static Principal MasterPage {
			get
			{
				return _principal ?? (_principal = new Principal());
			}
		}
		internal static FundosDeInvestimento FundosDeInvestimento {
			get
			{
                return _fundosInvestimento = new FundosDeInvestimento();
			}
		}
		internal static INSS Inss {
			get
			{
                return _inss = new INSS();
			}
		}
        //-------------------------------------------------------------------------------------------------------------// Tarifas Begin
		internal static TarifasPFLista TarifasPFLista {
			get
			{
                return _tarifasPfLista = new TarifasPFLista();
			}
		}
		internal static TarifasPJLista TarifasPJLista {
			get
			{
                return _tarifasPjLista = new TarifasPJLista();
			}
		}
		internal static TarifasPF TarifasPF {
			get
			{
                return _tarifasPf = new TarifasPF();
			}
		}
		internal static TarifasPJ TarifasPJ {
			get
			{
                return _tarifasPj = new TarifasPJ();
			}
		}
        //-----------------------------------------------//-- Old
        internal static TarifasPFLista_old TarifasPFLista_old
        {
            get
            {
                return _tarifasPfLista_old = new TarifasPFLista_old();
            }
        }
        internal static TarifasPJLista_old TarifasPJLista_old
        {
            get
            {
                return _tarifasPjLista_old = new TarifasPJLista_old();
            }
        }
        internal static TarifasPF_old TarifasPF_old
        {
            get
            {
                return _tarifasPf_old = new TarifasPF_old();
            }
        }
        internal static TarifasPJ_old TarifasPJ_old
        {
            get
            {
                return _tarifasPj_old = new TarifasPJ_old();
            }
        }
        //-----------------------------------------------//-- Vigências
        internal static TarifasPFVigencias TarifasPfVigencias
        {
            get
            {
                return _tarifasPfVigencias = new TarifasPFVigencias();
            }
        }
        internal static TarifasPJVigencias TarifasPjVigencias
        {
            get
            {
                return _tarifasPjVigencias = new TarifasPJVigencias();
            }
        }
        //-------------------------------------------------------------------------------------------------------------// Tarifas End
        internal static InformativoAoPublico InformativoAoPublico {
			get
			{
                return _informativoAoPublico = new InformativoAoPublico();
			}
		}
		internal static CanaisDeAcesso CanaisDeAcesso {
			get
			{
                return _canaisAcesso = new CanaisDeAcesso();
			}
		}
		internal static SCR Scr {
			get
			{
                return _scr = new SCR();
			}
		}
		internal static Procon Procon {
			get
			{
                return _procon = new Procon();
			}
		}
		internal static ReclamacoesOuSugestoes ReclamacoesOuSugestoes {
			get
			{
                return _reclamacoesSugestoes = new ReclamacoesOuSugestoes();
			}
		}
		internal static PrimeMenu PrimeMenu {
			get
			{
				return _primeMenu ?? (_primeMenu = new PrimeMenu());
			}
		}
		internal static FolhetosIndice FolhetosIndice {
			get
			{
				return _folhetosIndice ?? (_folhetosIndice = new FolhetosIndice());
			}
		}
		internal static FolhetosPF FolhetosPF {
			get
			{
				return _folhetosPF ?? (_folhetosPF = new FolhetosPF());
			}
		}
		internal static FolhetosEmpresasNegocios FolhetosPJ {
			get
			{
				return _folhetosPJ ?? (_folhetosPJ = new FolhetosEmpresasNegocios());
			}
		}
		internal static FolhetosExclusive FolhetosExclusive {
			get
			{
				return _folhetosExclusive ?? (_folhetosExclusive = new FolhetosExclusive());
			}
		}
		internal static PrimeInformativoAoPublico PrimeInformativoAoPublico {
			get
			{
                return _primeInformativo = new PrimeInformativoAoPublico();
			}
		}
		internal static Folhetos PrimeFolhetos {
			get
			{
				return _primeFolhetos ?? (_primeFolhetos = new Folhetos());
			}
		}
		internal static PrimeFundosDeInvestimento PrimeFundosDeInvestimento {
			get
			{
                return _primeFundosDeInvestimento = new PrimeFundosDeInvestimento();
			}
		}
		internal static PrimeSCR PrimeSCR {
			get
			{
                return _primeScr = new PrimeSCR();
			}
		}
        //-------------------------------------------------------------------------------------------------------------// Prime Tarifas Begin
        internal static PrimePfLista PrimePFLista {
			get {
                return _primePFLista = new PrimePfLista();
            }
		}
		internal static PrimePjLista PrimePJLista {
			get {
                return _primePJLista = new PrimePjLista();
            }
		}
		internal static PrimePF PrimePF {
			get
			{
                return _primePf = new PrimePF();
            }
		}
		internal static PrimePJ PrimePJ {
			get
			{
                return _primePj = new PrimePJ();
            }
		}
        //-----------------------------------------------//-- Old
        internal static PrimePfLista_old PrimePFLista_old
        {
            get
            {
                return _primePFLista_old = new PrimePfLista_old();
            }
        }
        internal static PrimePF_old PrimePF_old
        {
            get
            {
                return _primePf_old = new PrimePF_old();
            }
        }
        //-----------------------------------------------//-- Vigências
        internal static PrimePFVigencias PrimePfVigencias
        {
            get
            {
                return _primePfVigencias = new PrimePFVigencias();
            }
        }
        //-------------------------------------------------------------------------------------------------------------// Prime Tarifas End
        internal static Apps.Folhetos.FolhetosNavegador FolhetosNavegadorPF {
			get
			{
                return _folhetosNavegadorPF = new Apps.Folhetos.FolhetosNavegador(1, "Bradesco_InfoUteis\\Folhetos\\PF");
			}
		}
		internal static Apps.Folhetos.FolhetosNavegador FolhetosNavegadorPJ {
			get
			{
                return _folhetosNavegadorPJ = new Apps.Folhetos.FolhetosNavegador(1, "Bradesco_InfoUteis\\Folhetos\\Empresas");
			}
		}
		internal static Apps.Folhetos.FolhetosNavegador FolhetosNavegadorExclusive {
			get
			{
                return _folhetosNavegadorExclusive = new Apps.Folhetos.FolhetosNavegador(1, "Bradesco_InfoUteis\\Folhetos\\Exclusive");
			}
		}
        internal static AL StateAL
        {
            get
            {
                return _stateAl = new AL();
            }
        }
        internal static AM StateAM
        {
            get
            {
                return _stateAm = new AM();
            }
        }
        internal static CE StateCE
        {
            get
            {
                return _stateCe = new CE();
            }
        }
        internal static ES StateES
        {
            get
            {
                return _stateEs = new ES();
            }
        }
        internal static GO StateGO
        {
            get
            {
                return _stateGo = new GO();
            }
        }
        internal static MA StateMA
        {
            get
            {
                return _stateMa = new MA();
            }
        }
        internal static Apps.Estados.MS StateMS
        {
            get
            {
                return _stateMS = new Apps.Estados.MS();
            }
        }
        internal static MT StateMT
        {
            get
            {
                return _stateMt = new MT();
            }
        }
        internal static PA StatePA
        {
            get
            {
                return _statePa = new PA();
            }
        }
        internal static PE StatePE
        {
            get
            {
                return _statePe = new PE();
            }
        }
        internal static PI StatePI
        {
            get
            {
                return _statePi = new PI();
            }
        }
        internal static RN StateRN
        {
            get
            {
                return _stateRn = new RN();
            }
        }
        internal static RR StateRR
        {
            get
            {
                return _stateRr = new RR();
            }
        }
        internal static TO StateTO
        {
            get
            {
                return _stateTo = new TO();
            }
        }
        internal static BA StateBA {
			get
			{
                return _stateBa = new BA();
			}
		}
		internal static DF StateDF {
			get
			{
                return _stateDf = new DF();
			}
		}
		internal static MG StateMG {
			get
			{
                return _stateMg = new MG();
			}
		}
		internal static PR StatePR {
			get
			{
                return _statePr = new PR();
			}
		}
		internal static RJ StateRJ {
			get
			{
                return _stateRj = new RJ();
			}
		}
		internal static RS StateRS {
			get
			{
                return _stateRs = new RS();
			}
		}
		internal static SC StateSC {
			get
			{
                return _stateSc = new SC();
			}
		}
		internal static SP StateSP {
			get
			{
                return _stateSp = new SP();
			}
		}

		public static AjudaMenuPrincipal AjudaMenuPrincipal
		{
			get
			{
				return _ajudaMenuPrincipal ?? (_ajudaMenuPrincipal = new AjudaMenuPrincipal());
			}
		}

		public static AjudaMenuInterno AjudaMenuInterno
		{
			get
			{
				return _ajudaMenuInterno ?? (_ajudaMenuInterno = new AjudaMenuInterno());
			}
		}
	}
}

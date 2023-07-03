using System;

namespace DBTools.classes
{
	internal class RegistrosINI
	{
        private string m_arquivo        = string.Empty;
        private string m_sessao         = string.Empty;
		private DLLFuncoes.ArquivoINI   m_arquivoINI;

        #region PROPRIEDADES

        /// <summary>
        /// Caminho do arquivo.
        /// </summary>
        internal string Arquivo
        {
            get { return m_arquivo; }
            set { m_arquivo = value; }
        }
        /// <summary>
        /// Sessão a ler ou gravar
        /// </summary>
        public string Sessao
        {
            get { return m_sessao; }
            set { m_sessao = value; }
        }

        #endregion

		/// <summary>
		/// Tem todas as funções para manipular arquivos INI.
		/// </summary>
		internal RegistrosINI()
		{
			m_arquivoINI	= new DLLFuncoes.ArquivoINI();
		}
		/// <summary>
		/// Tem todas as funções para manipular arquivos INI.
		/// </summary>
		/// <param name="Arquivo">Caminho do arquivo ini</param>
		internal RegistrosINI(string Arquivo)
		{
			m_arquivo = Arquivo;
		}
		
		#region LER
		internal string Ler(string Chave, string ValorDefault)
		{
			return m_arquivoINI.LerINI(Arquivo, Sessao, Chave, ValorDefault);
		}
		internal int Ler(string Chave, int ValorDefault)
		{
			return Convert.ToInt32(m_arquivoINI.LerINI(Arquivo, Sessao, Chave, ValorDefault.ToString()));
		}

		internal bool Ler(string Chave, bool ValorDefault)
		{
			return Convert.ToBoolean(m_arquivoINI.LerINI(Arquivo, Sessao, Chave, ValorDefault.ToString()));
		}

		#endregion

		#region GRAVAR
		internal void Gravar(string Chave, string Valor)
		{
			m_arquivoINI.GrvarINI(Arquivo, Sessao, Chave, Valor);
		}
		internal void Gravar(string Chave, int Valor)
		{
			m_arquivoINI.GrvarINI(Arquivo, Sessao, Chave, Valor.ToString());
		}
		internal void Gravar(string Chave, bool Valor)
		{
			m_arquivoINI.GrvarINI(Arquivo, Sessao, Chave, Valor.ToString());
		}
		#endregion
		
    }
}
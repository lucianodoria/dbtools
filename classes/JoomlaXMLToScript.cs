using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DBTools
{
    [XmlRoot(ElementName = "SITE")]
    public class SITE
    {
        [XmlElement(ElementName = "CATEGORIAS")]
        public CATEGORIAS CATEGORIAS { get; set; }
        [XmlElement(ElementName = "IMOVEIS")]
        public IMOVEIS IMOVEIS { get; set; }
        [XmlElement(ElementName = "CLIENTES")]
        public CLIENTES CLIENTES { get; set; }
        [XmlElement(ElementName = "CIDADES")]
        public CIDADES CIDADES { get; set; }
        [XmlElement(ElementName = "BAIRROS")]
        public BAIRROS BAIRROS { get; set; }
        //[XmlElement(ElementName = "USUARIOS")]
        //public List<USUARIOS> USUARIOS { get; set; }
        [XmlElement(ElementName = "USUARIOS")]
        public List<DESCRICAO> USUARIOS { get; set; }
        [XmlElement(ElementName = "CARAC_IMOVEL")]
        public CARAC_IMOVEL CARAC_IMOVEL { get; set; }
        [XmlElement(ElementName = "CARACTERISTICAS")]
        public CARACTERISTICAS CARACTERISTICAS { get; set; }
        [XmlElement(ElementName = "TIPOCLIENTEPROPRIETARIO")]
        public TIPOCLIENTEPROPRIETARIO TIPOCLIENTEPROPRIETARIO { get; set; }
        [XmlElement(ElementName = "CAPTADORESIMOVEL")]
        public CAPTADORESIMOVEL CAPTADORESIMOVEL { get; set; }
        [XmlElement(ElementName = "CAPTADORESPROP")]
        public CAPTADORESPROP CAPTADORESPROP { get; set; }
        [XmlElement(ElementName = "TELEFONECLIENTE")]
        public TELEFONECLIENTE TELEFONECLIENTE { get; set; }
        [XmlElement(ElementName = "EMAILCLIENTE")]
        public EMAILCLIENTE EMAILCLIENTE { get; set; }
        [XmlElement(ElementName = "PORTALIMOVEL")]
        public PORTALIMOVEL PORTALIMOVEL { get; set; }
        [XmlElement(ElementName = "SITUACOESIMOVEL")]
        public SITUACOESIMOVEL SITUACOESIMOVEL { get; set; }
        [XmlElement(ElementName = "OCUPACOESIMOVEL")]
        public OCUPACOESIMOVEL OCUPACOESIMOVEL { get; set; }
    }
    [XmlRoot(ElementName = "TIPOSCATEGORIA")]
    public class TIPOSCATEGORIA
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "CATEGORIA")]
        public string CATEGORIA { get; set; }
    }

    [XmlRoot(ElementName = "CATEGORIAS")]
    public class CATEGORIAS
    {
        [XmlElement(ElementName = "TIPOSCATEGORIA")]
        public List<TIPOSCATEGORIA> TIPOSCATEGORIA { get; set; }
    }

    [XmlRoot(ElementName = "TIPODOIMOVEL")]
    public class TIPODOIMOVEL
    {
        [XmlElement(ElementName = "TIPO")]
        public List<string> TIPO { get; set; }
    }

    [XmlRoot(ElementName = "FINALIDADES")]
    public class FINALIDADES
    {
        [XmlElement(ElementName = "FINALIDADE")]
        public List<string> FINALIDADE { get; set; }
    }

    [XmlRoot(ElementName = "DESCRICAO")]
    public class DESCRICAO
    {
        [XmlElement(ElementName = "FOTO")]
        public string FOTO { get; set; }
        [XmlElement(ElementName = "LEGENDA")]
        public string LEGENDA { get; set; }
        [XmlElement(ElementName = "ID_IMOVEL")]
        public string ID_IMOVEL { get; set; }
        [XmlElement(ElementName = "ID_CARACTERISTICA")]
        public string ID_CARACTERISTICA { get; set; }
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "TIPOINTERNO")]
        public string TIPOINTERNO { get; set; }
        [XmlElement(ElementName = "TIPO")]
        public string TIPO { get; set; }
        [XmlElement(ElementName = "TERMO")]
        public string TERMO { get; set; }
        [XmlElement(ElementName = "CATEGORIA")]
        public string CATEGORIA { get; set; }
        [XmlElement(ElementName = "DT_CADASTRO")]
        public string DT_CADASTRO { get; set; }
        [XmlElement(ElementName = "PROPRIETARIO")]
        public string PROPRIETARIO { get; set; }
        [XmlElement(ElementName = "CAPTADORES")]
        public string CAPTADORES { get; set; }
        [XmlElement(ElementName = "IMOVEL")]
        public string IMOVEL { get; set; }
        [XmlElement(ElementName = "TELEFONE")]
        public string TELEFONE { get; set; }
        [XmlElement(ElementName = "DESCRICAO")]
        public string DESCRICAO2 { get; set; }
        [XmlElement(ElementName = "CLIENTE")]
        public string CLIENTE { get; set; }
        [XmlElement(ElementName = "EMAIL")]
        public string EMAIL { get; set; }
        [XmlElement(ElementName = "PORTAL")]
        public string PORTAL { get; set; }
    }

    [XmlRoot(ElementName = "FOTOS")]
    public class FOTOS
    {
        [XmlElement(ElementName = "DESCRICAO")]
        public List<DESCRICAO> DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "IMOVEL")]
    public class IMOVEL
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "CATEGORIA")]
        public string CATEGORIA { get; set; }
        [XmlElement(ElementName = "DORMITORIO")]
        public string DORMITORIO { get; set; }
        [XmlElement(ElementName = "SUITE")]
        public string SUITE { get; set; }
        [XmlElement(ElementName = "BANHEIRO")]
        public string BANHEIRO { get; set; }
        [XmlElement(ElementName = "BAIRRO")]
        public string BAIRRO { get; set; }
        [XmlElement(ElementName = "DATA")]
        public string DATA { get; set; }
        [XmlElement(ElementName = "VALOR")]
        public string VALOR { get; set; }
        [XmlElement(ElementName = "CORPO")]
        public string CORPO { get; set; }
        [XmlElement(ElementName = "DESTAQUE")]
        public string DESTAQUE { get; set; }
        [XmlElement(ElementName = "CONDOMINIO")]
        public string CONDOMINIO { get; set; }
        [XmlElement(ElementName = "ENDERECO")]
        public string ENDERECO { get; set; }
        [XmlElement(ElementName = "CIDADE")]
        public string CIDADE { get; set; }
        [XmlElement(ElementName = "IDCIDADE")]
        public string IDCIDADE { get; set; }
        [XmlElement(ElementName = "ELEVADOR")]
        public string ELEVADOR { get; set; }
        [XmlElement(ElementName = "PROPRIETARIO")]
        public string PROPRIETARIO { get; set; }
        [XmlElement(ElementName = "AREAUTIL")]
        public string AREAUTIL { get; set; }
        [XmlElement(ElementName = "PERMUTA")]
        public string PERMUTA { get; set; }
        [XmlElement(ElementName = "FINANCIAMENTO")]
        public string FINANCIAMENTO { get; set; }
        [XmlElement(ElementName = "TIPOINTERNO")]
        public string TIPOINTERNO { get; set; }
        [XmlElement(ElementName = "SALAS")]
        public string SALAS { get; set; }
        [XmlElement(ElementName = "IDADEIMOVEL")]
        public string IDADEIMOVEL { get; set; }
        [XmlElement(ElementName = "TOPOGRAFIA")]
        public string TOPOGRAFIA { get; set; }
        [XmlElement(ElementName = "IPTU")]
        public string IPTU { get; set; }
        [XmlElement(ElementName = "FORMAMEDIDA")]
        public string FORMAMEDIDA { get; set; }
        [XmlElement(ElementName = "HITS")]
        public string HITS { get; set; }
        [XmlElement(ElementName = "DISPONIVEL")]
        public string DISPONIVEL { get; set; }
        [XmlElement(ElementName = "OCUPANTES")]
        public string OCUPANTES { get; set; }
        [XmlElement(ElementName = "GARAGEM")]
        public string GARAGEM { get; set; }
        [XmlElement(ElementName = "GARAGEMCOBERTA")]
        public string GARAGEMCOBERTA { get; set; }
        [XmlElement(ElementName = "AREALAZER")]
        public string AREALAZER { get; set; }
        [XmlElement(ElementName = "DISTCENTRO")]
        public string DISTCENTRO { get; set; }
        [XmlElement(ElementName = "DISTPRAIA")]
        public string DISTPRAIA { get; set; }
        [XmlElement(ElementName = "DISTAEROPORTO")]
        public string DISTAEROPORTO { get; set; }
        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }
        [XmlElement(ElementName = "FORMAPAG")]
        public string FORMAPAG { get; set; }
        [XmlElement(ElementName = "AREACONSTRUIDA")]
        public string AREACONSTRUIDA { get; set; }
        [XmlElement(ElementName = "TITULO")]
        public string TITULO { get; set; }
        [XmlElement(ElementName = "NUMERO")]
        public string NUMERO { get; set; }
        [XmlElement(ElementName = "COMPLEMENTO")]
        public string COMPLEMENTO { get; set; }
        [XmlElement(ElementName = "CEP")]
        public string CEP { get; set; }
        [XmlElement(ElementName = "REFERENCIA")]
        public string REFERENCIA { get; set; }
        [XmlElement(ElementName = "SITUACAO")]
        public string SITUACAO { get; set; }
        [XmlElement(ElementName = "OCUPACAO")]
        public string OCUPACAO { get; set; }
        [XmlElement(ElementName = "ACEITAFINANCIAMENTO")]
        public string ACEITAFINANCIAMENTO { get; set; }
        [XmlElement(ElementName = "VALORLOCACAO")]
        public string VALORLOCACAO { get; set; }
        [XmlElement(ElementName = "VISTORIA")]
        public string VISTORIA { get; set; }
        [XmlElement(ElementName = "LOCALCHAVES")]
        public string LOCALCHAVES { get; set; }
        [XmlElement(ElementName = "EXCLUSIVIDADE")]
        public string EXCLUSIVIDADE { get; set; }
        [XmlElement(ElementName = "DATAEXCLUSIVIDADE")]
        public string DATAEXCLUSIVIDADE { get; set; }
        [XmlElement(ElementName = "NUMPLACA")]
        public string NUMPLACA { get; set; }
        [XmlElement(ElementName = "PEDIDOCOLOCACAO")]
        public string PEDIDOCOLOCACAO { get; set; }
        [XmlElement(ElementName = "DATACOLOCACAO")]
        public string DATACOLOCACAO { get; set; }
        [XmlElement(ElementName = "PEDIDORETIRADA")]
        public string PEDIDORETIRADA { get; set; }
        [XmlElement(ElementName = "DATARETIRADA")]
        public string DATARETIRADA { get; set; }
        [XmlElement(ElementName = "PREFEITURA")]
        public string PREFEITURA { get; set; }
        [XmlElement(ElementName = "CARTORIO")]
        public string CARTORIO { get; set; }
        [XmlElement(ElementName = "ELETRICIDADE")]
        public string ELETRICIDADE { get; set; }
        [XmlElement(ElementName = "SANEAMENTO")]
        public string SANEAMENTO { get; set; }
        [XmlElement(ElementName = "DOCUMENTACAO")]
        public string DOCUMENTACAO { get; set; }
        [XmlElement(ElementName = "GOOGLEMAP")]
        public string GOOGLEMAP { get; set; }
        [XmlElement(ElementName = "YOUTUBE")]
        public string YOUTUBE { get; set; }
        [XmlElement(ElementName = "REGIAO")]
        public string REGIAO { get; set; }
        [XmlElement(ElementName = "VENDACONJUNTA")]
        public string VENDACONJUNTA { get; set; }
        [XmlElement(ElementName = "EXIBIRIMOVELSITE")]
        public string EXIBIRIMOVELSITE { get; set; }
        [XmlElement(ElementName = "FACEDOSOL")]
        public string FACEDOSOL { get; set; }
        [XmlElement(ElementName = "INDICADOR")]
        public string INDICADOR { get; set; }
        [XmlElement(ElementName = "AREA")]
        public string AREA { get; set; }
        [XmlElement(ElementName = "METRAGEM")]
        public string METRAGEM { get; set; }
        [XmlElement(ElementName = "OPORTUNIDADE")]
        public string OPORTUNIDADE { get; set; }
        [XmlElement(ElementName = "DESTAQUELATERAL")]
        public string DESTAQUELATERAL { get; set; }
        [XmlElement(ElementName = "USUCADASTRO")]
        public string USUCADASTRO { get; set; }
        [XmlElement(ElementName = "USUALTEROU")]
        public string USUALTEROU { get; set; }
        [XmlElement(ElementName = "ULTIMAALTERACAO")]
        public string ULTIMAALTERACAO { get; set; }
        [XmlElement(ElementName = "TEMFOTO")]
        public string TEMFOTO { get; set; }
        [XmlElement(ElementName = "DATAATUALIZACAO")]
        public string DATAATUALIZACAO { get; set; }
        [XmlElement(ElementName = "TITLE")]
        public string TITLE { get; set; }
        [XmlElement(ElementName = "DESCRIPTION")]
        public string DESCRIPTION { get; set; }
        [XmlElement(ElementName = "KEYWORDS")]
        public string KEYWORDS { get; set; }
        [XmlElement(ElementName = "LATITUDE")]
        public string LATITUDE { get; set; }
        [XmlElement(ElementName = "LONGITUDE")]
        public string LONGITUDE { get; set; }
        [XmlElement(ElementName = "EXIBIRENDERECO")]
        public string EXIBIRENDERECO { get; set; }
        [XmlElement(ElementName = "IDBAIRRO")]
        public string IDBAIRRO { get; set; }
        [XmlElement(ElementName = "DATA_CAPTACAO")]
        public string DATA_CAPTACAO { get; set; }
        [XmlElement(ElementName = "EMPREENDIMENTO")]
        public string EMPREENDIMENTO { get; set; }
        [XmlElement(ElementName = "NUMEROANDAR")]
        public string NUMEROANDAR { get; set; }
        [XmlElement(ElementName = "MOEDA")]
        public string MOEDA { get; set; }
        [XmlElement(ElementName = "CERTIFICADO_ENERGETICO")]
        public string CERTIFICADO_ENERGETICO { get; set; }
        [XmlElement(ElementName = "ANO_CONSTRUCAO")]
        public string ANO_CONSTRUCAO { get; set; }
        [XmlElement(ElementName = "LAVABO")]
        public string LAVABO { get; set; }
        [XmlElement(ElementName = "OTIMIZACAO_CODE")]
        public string OTIMIZACAO_CODE { get; set; }
        [XmlElement(ElementName = "CAMASOLT")]
        public string CAMASOLT { get; set; }
        [XmlElement(ElementName = "CAMACAS")]
        public string CAMACAS { get; set; }
        [XmlElement(ElementName = "ESTRATO")]
        public string ESTRATO { get; set; }
        [XmlElement(ElementName = "TIPODOIMOVEL")]
        public TIPODOIMOVEL TIPODOIMOVEL { get; set; }
        [XmlElement(ElementName = "FINALIDADES")]
        public FINALIDADES FINALIDADES { get; set; }
        [XmlElement(ElementName = "FOTOS")]
        public FOTOS FOTOS { get; set; }
    }

    [XmlRoot(ElementName = "IMOVEIS")]
    public class IMOVEIS
    {
        [XmlElement(ElementName = "IMOVEL")]
        public List<IMOVEL> IMOVEL { get; set; }
    }

    [XmlRoot(ElementName = "CLIENTE")]
    public class CLIENTE
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "NOME")]
        public string NOME { get; set; }
        [XmlElement(ElementName = "ENDERECO")]
        public string ENDERECO { get; set; }
        [XmlElement(ElementName = "BAIRRO")]
        public string BAIRRO { get; set; }
        [XmlElement(ElementName = "CIDADE")]
        public string CIDADE { get; set; }
        [XmlElement(ElementName = "ESTADO")]
        public string ESTADO { get; set; }
        [XmlElement(ElementName = "PRIMCONTATO")]
        public string PRIMCONTATO { get; set; }
        [XmlElement(ElementName = "TRATAMENTO")]
        public string TRATAMENTO { get; set; }
        [XmlElement(ElementName = "EMPRESA")]
        public string EMPRESA { get; set; }
        [XmlElement(ElementName = "SITUACAO")]
        public string SITUACAO { get; set; }
        [XmlElement(ElementName = "INTERESSE")]
        public string INTERESSE { get; set; }
        [XmlElement(ElementName = "CORPO")]
        public string CORPO { get; set; }
        [XmlElement(ElementName = "PESSOA")]
        public string PESSOA { get; set; }
        [XmlElement(ElementName = "NASCIMENTO")]
        public string NASCIMENTO { get; set; }
        [XmlElement(ElementName = "RG")]
        public string RG { get; set; }
        [XmlElement(ElementName = "CPF")]
        public string CPF { get; set; }
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }
        [XmlElement(ElementName = "NACIONALIDADE")]
        public string NACIONALIDADE { get; set; }
        [XmlElement(ElementName = "NATURALIDADE")]
        public string NATURALIDADE { get; set; }
        [XmlElement(ElementName = "ESTADOCIVIL")]
        public string ESTADOCIVIL { get; set; }
        [XmlElement(ElementName = "REGIME")]
        public string REGIME { get; set; }
        [XmlElement(ElementName = "ESCOLARIDADE")]
        public string ESCOLARIDADE { get; set; }
        [XmlElement(ElementName = "PROFISSAO")]
        public string PROFISSAO { get; set; }
        [XmlElement(ElementName = "CARGO")]
        public string CARGO { get; set; }
        [XmlElement(ElementName = "RAMO")]
        public string RAMO { get; set; }
        [XmlElement(ElementName = "RENDA1")]
        public string RENDA1 { get; set; }
        [XmlElement(ElementName = "RENDA2")]
        public string RENDA2 { get; set; }
        [XmlElement(ElementName = "DEPENDENTES")]
        public string DEPENDENTES { get; set; }
        [XmlElement(ElementName = "CONJUGE")]
        public string CONJUGE { get; set; }
        [XmlElement(ElementName = "CNASCIMENTO")]
        public string CNASCIMENTO { get; set; }
        [XmlElement(ElementName = "CRG")]
        public string CRG { get; set; }
        [XmlElement(ElementName = "CCPF")]
        public string CCPF { get; set; }
        [XmlElement(ElementName = "CNACIONALIDADE")]
        public string CNACIONALIDADE { get; set; }
        [XmlElement(ElementName = "CNATURALIDADE")]
        public string CNATURALIDADE { get; set; }
        [XmlElement(ElementName = "CPROFISSAO")]
        public string CPROFISSAO { get; set; }
        [XmlElement(ElementName = "CEP")]
        public string CEP { get; set; }
        [XmlElement(ElementName = "CENDERECO")]
        public string CENDERECO { get; set; }
        [XmlElement(ElementName = "CBAIRRO")]
        public string CBAIRRO { get; set; }
        [XmlElement(ElementName = "CCEP")]
        public string CCEP { get; set; }
        [XmlElement(ElementName = "CCIDADE")]
        public string CCIDADE { get; set; }
        [XmlElement(ElementName = "CESTADO")]
        public string CESTADO { get; set; }
        [XmlElement(ElementName = "USUCADASTRO")]
        public string USUCADASTRO { get; set; }
        [XmlElement(ElementName = "DATACADASTRO")]
        public string DATACADASTRO { get; set; }
        [XmlElement(ElementName = "USUALTEROU")]
        public string USUALTEROU { get; set; }
        [XmlElement(ElementName = "ULTIMAALTERACAO")]
        public string ULTIMAALTERACAO { get; set; }
        [XmlElement(ElementName = "BANCO")]
        public string BANCO { get; set; }
        [XmlElement(ElementName = "AGENCIA")]
        public string AGENCIA { get; set; }
        [XmlElement(ElementName = "OPERACAO")]
        public string OPERACAO { get; set; }
        [XmlElement(ElementName = "CONTA")]
        public string CONTA { get; set; }
        [XmlElement(ElementName = "FAVORECIDO")]
        public string FAVORECIDO { get; set; }
        [XmlElement(ElementName = "IDBAIRRO")]
        public string IDBAIRRO { get; set; }
        [XmlElement(ElementName = "IDCBAIRRO")]
        public string IDCBAIRRO { get; set; }
        [XmlElement(ElementName = "IDCIDADE")]
        public string IDCIDADE { get; set; }
        [XmlElement(ElementName = "IDCCIDADE")]
        public string IDCCIDADE { get; set; }
        [XmlElement(ElementName = "IDFAVORITO")]
        public string IDFAVORITO { get; set; }
        [XmlElement(ElementName = "DOCUMENTO3")]
        public string DOCUMENTO3 { get; set; }
        [XmlElement(ElementName = "DOCUMENTO4")]
        public string DOCUMENTO4 { get; set; }
        [XmlElement(ElementName = "SENHA")]
        public string SENHA { get; set; }
        [XmlElement(ElementName = "HASH")]
        public string HASH { get; set; }
        [XmlElement(ElementName = "CONFIRMADO_EMAIL")]
        public string CONFIRMADO_EMAIL { get; set; }
        [XmlElement(ElementName = "NOME_SITE")]
        public string NOME_SITE { get; set; }
        [XmlElement(ElementName = "NIMOVEIS")]
        public string NIMOVEIS { get; set; }
    }

    [XmlRoot(ElementName = "CLIENTES")]
    public class CLIENTES
    {
        [XmlElement(ElementName = "CLIENTE")]
        public List<CLIENTE> CLIENTE { get; set; }
    }

    [XmlRoot(ElementName = "CIDADE")]
    public class CIDADE
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "ESTADO")]
        public string ESTADO { get; set; }
        [XmlElement(ElementName = "CIDADE")]
        public string CIDADENOME { get; set; }
        [XmlElement(ElementName = "PAIS")]
        public string PAIS { get; set; }
        [XmlElement(ElementName = "PRINCIPAL")]
        public string PRINCIPAL { get; set; }
        [XmlElement(ElementName = "IDCIDADE")]
        public string IDCIDADE { get; set; }
        [XmlElement(ElementName = "SIGLA")]
        public string SIGLA { get; set; }
        [XmlElement(ElementName = "CONDADO")]
        public string CONDADO { get; set; }
    }

    [XmlRoot(ElementName = "CIDADES")]
    public class CIDADES
    {
        [XmlElement(ElementName = "CIDADE")]
        public List<CIDADE> CIDADE { get; set; }
    }

    [XmlRoot(ElementName = "BAIRRO")]
    public class BAIRRO
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "BAIRRO")]
        public string BAIRRONOME { get; set; }
        [XmlElement(ElementName = "IDCIDADE")]
        public string IDCIDADE { get; set; }
    }

    [XmlRoot(ElementName = "BAIRROS")]
    public class BAIRROS
    {
        [XmlElement(ElementName = "BAIRRO")]
        public List<BAIRRO> BAIRRO { get; set; }
    }

    [XmlRoot(ElementName = "USUARIO")]
    public class USUARIO
    {
        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }
        [XmlElement(ElementName = "USUARIO")]
        public string USUARIOLOGIN { get; set; }
        [XmlElement(ElementName = "NOME")]
        public string NOME { get; set; }
    }

    [XmlRoot(ElementName = "USUARIOS")]
    public class USUARIOS
    {
        [XmlElement(ElementName = "USUARIO")]
        public List<USUARIO> USUARIO { get; set; }
        [XmlElement(ElementName = "DESCRICAO")]
        public List<DESCRICAO> DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "CARAC_IMOVEL")]
    public class CARAC_IMOVEL
    {
        [XmlElement(ElementName = "DESCRICAO")]
        public List<DESCRICAO> DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "CARACTERISTICAS")]
    public class CARACTERISTICAS
    {
        [XmlElement(ElementName = "DESCRICAO")]
        public List<DESCRICAO> DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "TIPOCLIENTEPROPRIETARIO")]
    public class TIPOCLIENTEPROPRIETARIO
    {
        [XmlElement(ElementName = "DESCRICAO")]
        public List<DESCRICAO> DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "CAPTADORESIMOVEL")]
    public class CAPTADORESIMOVEL
    {
        [XmlElement(ElementName = "DESCRICAO")]
        public List<DESCRICAO> DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "CAPTADORESPROP")]
    public class CAPTADORESPROP
    {
        [XmlElement(ElementName = "DESCRICAO")]
        public List<DESCRICAO> DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "TELEFONECLIENTE")]
    public class TELEFONECLIENTE
    {
        [XmlElement(ElementName = "DESCRICAO")]
        public List<DESCRICAO> DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "EMAILCLIENTE")]
    public class EMAILCLIENTE
    {
        [XmlElement(ElementName = "DESCRICAO")]
        public List<DESCRICAO> DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "PORTALIMOVEL")]
    public class PORTALIMOVEL
    {
        [XmlElement(ElementName = "DESCRICAO")]
        public List<DESCRICAO> DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "SITUACAOIMOVEL")]
    public class SITUACAOIMOVEL
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "DESCRICAO")]
        public string DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "SITUACOESIMOVEL")]
    public class SITUACOESIMOVEL
    {
        [XmlElement(ElementName = "SITUACAOIMOVEL")]
        public List<SITUACAOIMOVEL> SITUACAOIMOVEL { get; set; }
    }

    [XmlRoot(ElementName = "OCUPACAOIMOVEL")]
    public class OCUPACAOIMOVEL
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "DESCRICAO")]
        public string DESCRICAO { get; set; }
    }

    [XmlRoot(ElementName = "OCUPACOESIMOVEL")]
    public class OCUPACOESIMOVEL
    {
        [XmlElement(ElementName = "OCUPACAOIMOVEL")]
        public List<OCUPACAOIMOVEL> OCUPACAOIMOVEL { get; set; }
    }
}

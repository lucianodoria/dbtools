<?php
defined('_JEXEC') or die('Acesso restrito!');

class {TYPE}FilterEntity extends BaseFilterEntity
{
{VARS}
var ${SEARCH_TEXT}_exato = null;

    public function jsonSerialize()
    {
        return get_object_vars($this);
    }
}
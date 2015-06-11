#include "ContentTypeParser.h"

CONTENTRENDERERS ContentTypeParser::GetContentRendererType(string content) {
	return CONTENTRENDERERS::PLAIN_TEXT;
}

ContentTypeParser::ContentTypeParser() { }

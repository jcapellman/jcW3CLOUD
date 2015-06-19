#include "Config.h"

Config::Config() : Config(DEFAULT_CONFIG_FILENAME) { }

Config::Config(char * fileName) {
	readConfig(fileName);
}

void Config::readConfig(char * fileName) {
	FileReader fr;

	this->_mConfig = fr.GetMap(fileName, " ");
}

int Config::GetIntConfig(string key) {
	string value = this->GetStringConfig(key);

	if (value == "") {
		return 0;
	}

	return atoi(value.c_str());
}

int Config::GetIntConfig(CONFIG_KEYS configKey) {
	return GetIntConfig(enumToString(configKey));
}

string Config::enumToString(CONFIG_KEYS configKey) {
	switch (configKey) {
		case xres:
			return "xres";
		case yres:
			return "yres";
		case bpp:
			return "bpp";
		case server_address:
			return "server_address";
		case bookmark_filename:
			return "bookmark_filename";
	}

	return "";
}

string Config::GetStringConfig(CONFIG_KEYS configKey) {
	return GetStringConfig(enumToString(configKey));
}

string Config::GetStringConfig(string key) {
	int pos = this->_mConfig.find(key);

	if (pos == this->_mConfig.end()) {
		return "";
	}

	return pos->second;
}
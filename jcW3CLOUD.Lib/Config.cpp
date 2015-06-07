#include "Config.h"

Config::Config() : Config(DEFAULT_CONFIG_FILENAME) { }

Config::Config(char * fileName) {
	readConfig(fileName);
}

void Config::readConfig(char * fileName) {
	std::ifstream iConfig(fileName, std::ifstream::in);
	string line;

	if (!iConfig.is_open()) {
		return;
	}

	for (std::string line; std::getline(iConfig, line);) {
		string buffer;
		string key;

		stringstream ss(line);

		bool onKey = true;
		
		while (ss >> buffer) {
			if (!onKey) {
				this->_mConfig[key] = buffer;

				onKey = true;
			}

			key = buffer;
			onKey = false;
		}
	}

	iConfig.close();
}

int Config::GetIntConfig(string key) {
	string value = this->GetStringConfig(key);

	if (value == "") {
		return 0;
	}

	return atoi(value.c_str());
}

string Config::GetStringConfig(string key) {
	auto pos = this->_mConfig.find(key);

	if (pos == this->_mConfig.end()) {
		return "";
	}

	return pos->second;
}
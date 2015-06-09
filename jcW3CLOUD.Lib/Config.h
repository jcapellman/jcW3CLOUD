#include "Main.h"

enum CONFIG_KEYS {
	xres,
	yres,
	bpp,
	server_address
};

class Config {
	public:
		Config();
		Config(char * fileName);

		int GetIntConfig(CONFIG_KEYS configKey);
		string GetStringConfig(CONFIG_KEYS configKey);

		int GetIntConfig(string key);
		string GetStringConfig(string key);
	private:
		string enumToString(CONFIG_KEYS configKey);
		void readConfig(char * fileName);

		map<string, string> _mConfig;
};
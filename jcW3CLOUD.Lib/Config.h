#include "Main.h"

#include "FileReader.h"

enum CONFIG_KEYS {
	xres,
	yres,
	bpp,
	server_address,
	bookmark_filename
};

class Config {
	public:
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
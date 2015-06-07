#include "Main.h"

class Config {
	public:
		Config();
		Config(char * fileName);

		int GetIntConfig(string key);
		string GetStringConfig(string key);
	private:
		void readConfig(char * fileName);

		map<string, string> _mConfig;
};
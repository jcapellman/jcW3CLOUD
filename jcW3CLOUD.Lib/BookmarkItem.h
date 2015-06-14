#ifndef __BOOKMARKITEM__
#define __BOOKMARKITEM__

class BookmarkItem {
	public:
		BookmarkItem(int id, string description, string url) {
			this->_description = description;
			this->_url = url;
			this->_id = id;
		}

		string GetDescription() {
			return _description;
		}

		string GetUrl() {
			return _url;
		}

		int GetID() {
			return this->_id;
		}

		stringstream operator << (BookmarkItem &a) {
			stringstream tmp;

			tmp << a.GetID() << DEFAULT_BOOKMARK_DELIMETER << a.GetDescription() << DEFAULT_BOOKMARK_DELIMETER << a.GetUrl() << endl;

			return tmp;
		}
	private:
		string _description;
		string _url;

		int _id;
};
#endif

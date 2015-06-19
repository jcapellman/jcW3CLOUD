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
		
		std::ostream& operator<<(std::ostream& os) {
			os << GetID() << DEFAULT_BOOKMARK_DELIMETER << GetDescription() << DEFAULT_BOOKMARK_DELIMETER << GetUrl() << endl;

			return os;
		}
	private:
		string _description;
		string _url;

		int _id;
};
#endif

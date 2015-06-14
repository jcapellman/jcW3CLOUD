#ifndef __BOOKMARKITEM__
#define __BOOKMARKITEM__

class BookmarkItem {
	public:
		BookmarkItem(string description, string url) {
			this->_description = description;
			this->_url = url;
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
	private:
		string _description;
		string _url;

		int _id;
};
#endif

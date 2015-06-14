#include "BookmarkManager.h"

BookmarkManager::BookmarkManager(string fileName) {
	std::ifstream iConfig(fileName, std::ifstream::in);
	string line;

	if (!iConfig.is_open()) {
		return;
	}

	while (getline(iConfig, line)) {
		string description;
		string url;

		int positionIdx = line.find("||");

		if (positionIdx == string::npos) {
			continue;
		}

		description = line.substr(0, positionIdx);

		url = line.substr(positionIdx, line.length() - positionIdx);

		this->AddBookmark(description, url);
	}

	iConfig.close();
}

BookmarkManager::BookmarkManager() : BookmarkManager(DEFAULT_BOOKMARK_FILENAME) { }

bool BookmarkManager::AddBookmark(string description, string url) {
	BookmarkItem item = BookmarkItem(description, url);

	vector<BookmarkItem>::iterator it;

	it = this->_bookmarks.begin();

	this->_bookmarks.insert(it, item);

	return true;
}

bool BookmarkManager::RemoveBook(int id) {
	this->_bookmarks.erase(this->_bookmarks.begin() + id);

	return true;
}

vector<BookmarkItem> BookmarkManager::GetAll() {
	return this->_bookmarks;
}

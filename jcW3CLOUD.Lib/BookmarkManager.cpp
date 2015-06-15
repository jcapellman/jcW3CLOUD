#include "BookmarkManager.h"

BookmarkManager::BookmarkManager(string fileName) {
	FileReader fr;

	this->_bookmarks = fr.GetVector(fileName, "||");
}

BookmarkManager::BookmarkManager() : BookmarkManager(DEFAULT_BOOKMARK_FILENAME) { }

BookmarkManager::~BookmarkManager() {
	this->_bookmarks.clear();
}

int BookmarkManager::generateID() {
	int id = 0;
	bool found = true;

	while (found) {
		bool foundInIteration = false;

		for (unsigned int x = 0; x < _bookmarks.size(); x++) {
			BookmarkItem item = _bookmarks.at(x);

			if (item.GetID() == id) {
				foundInIteration = true;
			}
		}

		if (!foundInIteration) {
			found = false;
		} else {
			id++;
		}
	}

	return id;
}

bool BookmarkManager::WriteBookmarksToFile() {
	return true;
	//return FileWriter<vector<BookmarkItem>>(_bookmarks)->WriteFile(DEFAULT_BOOKMARK_FILENAME);
}

bool BookmarkManager::AddBookmark(string description, string url) {
	BookmarkItem item = BookmarkItem(this->generateID(), description, url);

	vector<BookmarkItem>::iterator it;

	it = this->_bookmarks.begin();

	this->_bookmarks.insert(it, item);

	return true;
}

bool BookmarkManager::RemoveBookmark(int id) {
	this->_bookmarks.erase(this->_bookmarks.begin() + id);

	return true;
}

vector<BookmarkItem> BookmarkManager::GetAll() {
	return this->_bookmarks;
}


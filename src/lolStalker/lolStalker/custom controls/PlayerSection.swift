//
//  PlayerSection.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/10/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

class PlayerSection: UIView {
    ////////////////////////////////////
    //Global Variables
    ////////////////////////////////////
    var title: String = "No title" {
        didSet {
            titleView.text = title
        }
    }
    
    var content: UIView? {
        didSet {
            if let content = content {
                addSubview(content)
                content.translatesAutoresizingMaskIntoConstraints = false
                content.topAnchor.constraint(equalTo: topView.bottomAnchor, constant: 20).isActive = true
                content.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
                content.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
                content.heightAnchor.constraint(equalToConstant: 400).isActive = true
            }
        }
    }
    
    ////////// END OF GLOBALS //////////
    
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    private let topView: UIView = {
        let view = UIView()
        view.backgroundColor = UIColor(hex: "#57626D")
//        view.frame.size = CGSize(width: 200, height: 55)
        return view
    }()
    
    private let titleView: UILabel = {
        let label = UILabel()
        label.textColor = UIColor(hex: "#CE9340")
        label.font = UIFont.systemFont(ofSize: 23)
        label.text = label.text?.capitalized
        return label
    }()
    
    ////////// END OF CONTROLS /////////
    override init(frame: CGRect) {
        super.init(frame: frame)
        setupView()
        setupSubViews()
        setupConstraints()
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    private func setupView() {
        titleView.text = title
    }
    
    private func setupSubViews() {
        addSubview(topView)
        topView.addSubview(titleView)
    }
    
    private func setupConstraints() {
        topView.translatesAutoresizingMaskIntoConstraints = false
        titleView.translatesAutoresizingMaskIntoConstraints = false
        
        topView.topAnchor.constraint(equalTo: topAnchor).isActive = true
        topView.heightAnchor.constraint(equalToConstant: 55).isActive = true
//        topView.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        topView.widthAnchor.constraint(equalToConstant: UIScreen.main.bounds.width).isActive = true
        topView.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        
        titleView.centerYAnchor.constraint(equalTo: topView.centerYAnchor).isActive = true
        titleView.leftAnchor.constraint(equalTo: topView.leftAnchor, constant: 8).isActive = true
     
    }
}
